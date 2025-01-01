#
#        ___         __         __   ______________     ________
#       / _ \\      /_/|       /_/| /_____________/|   / ______ \\
#      / //\ \\     | ||       | || |/____________|/  / //     \ \\
#     / //  \ \\    | ||       | ||       | ||       | ||       | ||
#    / //____\ \\   | ||       | ||       | ||       | ||       | ||
#   / //______\ \\  | ||       | ||       | ||       | ||       | ||
#  / //________\ \\ | |'_______| |'       | ||       | ||_______| ||
#  | ||        | ||  \ \______/ /         | ||        \ \______/ //
#  |_|/        |_|/   \________/          |_|/         \________/
#
#                    __        __   ____           ____
#                   /_/|      /_/| /___/\         /___/
#                   | ||      | || |  _\ \       /_  ||
#                   | ||      | || | ||\\ \     ///| ||
#                   \ \\      / // | || \\ \   /// | ||
#                    \ \\    / //  | ||  \\ \ ///  | ||
#                     \ \\_ / //   | ||   \\_//    | ||
#                      \ \_/ /     | ||    \_/     | ||
#                       \___/      |_|/            |_|/
#
#
#
# The goal of this tool is to simplify the workflow of every developer in fetching
# the right VHD and quickly spin up a VM
#
# This tool/script primarily solves below problems
#   1. Find RTM/Patched VHD from XP - RS3
#   2. Customize the VHD with dev tools needed for bug triage
#   3. Skip the time consuming OOBE experience via unattend.xml
#   4. Spin up a VM with basic configurations
#
# It took lot of inspiration from quick tool available in Razzle.
# But since quick tool is mainly geared towards the active branch developments.
# We had to create this tool.
#
# Usage:
#  Interactive Mode:
#   .\AutoVM.ps1
#     1. Create VM
#     2. Show RTM/Patched VHD locations
#     3. Create englightened VHDs for all platforms
#     4. Exit
#     Enter your choice:
#
# Platforms come in two flavors RTM or fully patched.
#
# Enlightening is the phase during which we can inject tools/unattend.xml
# To spin a new VM we make a copy of the englightened VHD and start the VM.
#
# The default VM Administrator password: Test@123
#
# git clone https://vineelko.visualstudio.com/_git/AutoVM C:\Users\<username>\Documents\WindowsPowerShell\Modules\AutoVM
#
# Now launch power shell and run New-AutoVM
#

param ($Platform, $VMName)

$AutoVMDateFormat = "MM-dd-yyyy hh:mm:ss tt";

$CloneReadMe = "
<= RS2
======
md src
cd src
set SDXROOT=%CD%
\\glacier\sdx\sdx enlist nt    vistasp2_ldr           minio com
\\glacier\sdx\sdx enlist win7  win7sp1_ldr            minio base minkernel
\\glacier\sdx\sdx enlist win8  win8_ldr               minio base minkernel mincore
\\glacier\sdx\sdx enlist Blue  winblue_ltsb           minio base minkernel mincore
\\glacier\sdx\sdx enlist TH    th1                    minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist TH    th1_st1                minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist TH    th1_st1_st2            minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist TH    th2_release            minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist TH    th2_release_sec        minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist TH    th2_release_sec_b      minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist RS1   rs1_release            minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist RS1   rs1_release_1          minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist RS1   rs1_release_1_2        minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist RS1   rs1_release_1_2_3      minio base minkernel onecore onecoreuap multi en-us
\\glacier\sdx\sdx enlist RS2   rs2_release_svc        minio base minkernel onecore onecoreuap
\\glacier\sdx\sdx enlist RS2   rs2_release_svc_1      minio base minkernel onecore onecoreuap
\\glacier\sdx\sdx enlist RS2   rs2_release_svc_1_2    minio base minkernel onecore onecoreuap
\\glacier\sdx\sdx enlist RS2   rs2_release_svc_1_2_3  minio base minkernel onecore onecoreuap

>= RS3
======
gvfs clone https://microsoft.visualstudio.com/_git/os
favbranch -b:official/rs_example
"

$global:config = $null;

Function AutoVMPrintInfo
{
    param($Message)

    Write-Host "$Message";
}

Function AutoVMPrintWarning
{
    param($Message)

    Write-Warning "$Message";
}

Function AutoVMLog
{
    param($Message, [switch]$Warning)

    $Message = "$((Get-Date).ToString($AutoVMDateFormat)): $Message";

    if ($Warning) { Write-Warning "$Message"; }
    else { Write-Host "$Message"; }
}

Function AutoVMLogWarning
{
    param($Message)

    AutoVMLog -Message $Message -Warning;
}

Function AutoVMLogInfo
{
    param($Message)

    AutoVMLog -Message $Message;
}

Function AutoVMScriptRoot
{
    $ScriptRoot = ""

    try {
        $ScriptRoot = Get-Variable -Name PSScriptRoot -ValueOnly -ErrorAction Stop
    }
    catch {
        $ScriptRoot = Split-Path $script:MyInvocation.MyCommand.Path
    }

    return $ScriptRoot
}

Function AutoVMFindPatchedVHDForGitRepos
{
    param($VMs)

    $RootPath = "\\winbuilds\release\{platform}_release_svc_{release}\{build}";# amd64fre\vhd\vhd_client_enterprise_en-us_vl\"

    foreach ($month in @(0, -1, -2, -3)) { # sometimes previous month might not have B release so we try three months from current month
        foreach ($key in @($VMs.Keys)) {
            #write-host $key;
            if ($VMs[$key] -eq "{}") {
                $vhdpath = $RootPath -replace "{platform}", $key;
                $vhdpath = $vhdpath -replace "{release}", $((Get-Date).AddMonths($month).ToString("yMMB"));
                $dirs = (dir ($vhdpath -split "{build}")[0] | sort -Property LastWriteTime -Descending)[1..8];
                foreach($dir in $dirs) {
                    $path = $vhdpath -replace "{build}", $dir.Name;
                    if ([System.IO.Directory]::Exists("$($path)\amd64fre\vhd\vhd_client_enterprise_en-us_vl")) {
                        $path = "$($path)\amd64fre\vhd\vhd_client_enterprise_en-us_vl\*.vhd"
                        $path = (dir $($path))[0].FullName;
                        $VMs[$key] = $path;
                        #write-host $VMs[$key];
                        break;
                    }
                }
            }
        }
    }
}

Function AutoVMGetConfig
{
    $ScriptRoot = AutoVMScriptRoot;

    $ConfigPath = "$ScriptRoot\AutoVMConfig.xml"

    [xml]$config = Get-Content $ConfigPath;

    $enlightenedvhdstore = $config.SelectSingleNode("/autovm/enlightenedvhdstore").InnerText;
    $vhdstore            = $config.SelectSingleNode("/autovm/vhdstore").InnerText;
    $vmconfigpath        = $config.SelectSingleNode("/autovm/vmconfigpath").InnerText;
    $toolspath           = $config.SelectSingleNode("/autovm/toolspath").InnerText;
    $ram                 = $config.SelectSingleNode("/autovm/ram").InnerText;
    $cores               = $config.SelectSingleNode("/autovm/cores").InnerText;
    $scratchvhdpath      = $config.SelectSingleNode("/autovm/scratchvhdpath").InnerText;

    $vms = [ordered]@{};

    if ($generalizedstore -eq ".") {
        $generalizedstore = "$ScriptRoot\generalized"
    }

    if ($enlightenedvhdstore -eq ".") {
        $enlightenedvhdstore = "$ScriptRoot\enlightenedvhdstore"
    }

    if ($vhdstore -eq ".") {
        $vhdstore = "$ScriptRoot\vhds"
    }

    if ($vmconfigpath -eq ".") {
        $vmconfigpath = "$ScriptRoot\vmconfig"
    }

    if ($toolspath -eq ".") {
        $toolspath = "$ScriptRoot\tools"
    }

    $ram = $ram/1;
    $config.SelectNodes("/autovm/generalized/vm") | % {$vms[$_.platform] = $_.path} | Out-Null;

    AutoVMFindPatchedVHDForGitRepos -VMs $vms;

    $global:config = [ordered]@{
        "enlightenedvhdstore" = $enlightenedvhdstore;
        "vhdstore"            = $vhdstore;
        "vmconfigpath"        = $vmconfigpath;
        "toolspath"           = $toolspath;
        "ram"                 = $ram;
        "cores"               = $cores;
        "scratchvhdpath"      = $scratchvhdpath;
        "vms"                 = $vms;
    };
}

Function AutoVMMountVHDInternal
{
    param($ImagePath, $MountPoint)
    Mount-DiskImage -ImagePath $ImagePath -NoDriveLetter -ErrorAction Stop
    try {
        $disk = Get-DiskImage -ImagePath $ImagePath | Get-Disk -ErrorAction Stop
        $partition = $disk | Get-Partition | Where-Object { $_.Type -eq "IFS" -or $_.Type -eq "Basic" }
        $partition | Add-PartitionAccessPath -AccessPath $MountPoint -ErrorAction Stop
        return $True;
    }
    catch {
        Dismount-DiskImage -ImagePath $ImagePath -ErrorAction Stop
        return $False;
    }
}

Function AutoVMDismountVHDInternal
{
    param($ImagePath, $MountPoint)
    try {
        $disk = Get-DiskImage -ImagePath $ImagePath | Get-Disk -ErrorAction Stop
        $partition = $disk | Get-Partition | Where-Object { $_.Type -eq "IFS" -or $_.Type -eq "Basic" }
        $partition | Remove-PartitionAccessPath -AccessPath $MountPoint -ErrorAction Stop
    }
    finally {
        Dismount-DiskImage -ImagePath $ImagePath -ErrorAction Stop | Out-Null
    }
}

Function AutoVMRemoveStaleVhds
{
    $config = $global:config;
    $vhdstore = $config['vhdstore'];
    Function AddToSet
    {
        param($Set, $Value);
        if (-not $Set.Contains($Value)) {
            $Set.Add($Value) | Out-Null;
        }
    }

    $UsedVHDS = New-Object System.Collections.Generic.HashSet[string];

    # Find all VHDs attached to VMs. Should count differencing VHDs
    AutoVMPrintInfo ("-" * 200);
    AutoVMPrintInfo ("|{0,-35}|{1, -163}|" -f "VM Name", "VHD Path(In Use)");
    AutoVMPrintInfo ("-" * 200);
    foreach ($Vm in Get-VM) {
        $Vhd = Get-VHD -VMId $Vm.VMId -ErrorAction Ignore;
        if ($Vhd) {
            AutoVMPrintInfo ("|{0,-35}|{1, -163}|" -f $($Vm.VMName), $($Vhd.Path));
            AddToSet -Set $UsedVHDS -Value $($Vhd.Path);
            $Vhd2 = $Vhd;
            while($Path = $Vhd2.ParentPath) {
                AutoVMPrintInfo ("|{0,-35}|{1, -163}|" -f "└──────────────────────────────────", $($Vhd.Path));
                AddToSet -Set $UsedVHDS -Value $Path;
                $Vhd2 = Get-Vhd -Path $Path;
            }
        }
    }
    AutoVMPrintInfo ("-" * 200);

    # Find all VHDs
    $AllVHDS = New-Object System.Collections.Generic.HashSet[string];
    (Get-ChildItem  -Path $vhdstore -Recurse -Filter *vhd*) | % { AddToSet -Set $AllVHDS -Value $($_.FullName)};

    # Find all VHDs not in use
    $StaleVHDS = $AllVHDS  | ? {$UsedVHDS -notcontains $_ };

    if ($StaleVHDS.Length -eq 0) {
        AutoVMLogInfo "No stale VHDs found" ;
        return;
    }

    # Print Stale VHDs table
    AutoVMPrintInfo ("-" * 200);
    AutoVMPrintInfo ("|{0,-200}|" -f "VHD Path(Stale)");
    AutoVMPrintInfo ("-" * 200);
    $StaleVHDS | %{ AutoVMPrintInfo ("|{0,-200}|" -f $_) };
    AutoVMPrintInfo ("-" * 200);

    $choice = Read-Host "Delete all stale VHDs(Y/N)?";
    if ($choice -eq "Y" ) {
        $StaleVHDS | Remove-Item -Force | Out-Null
    } else {
        AutoVMLogInfo "No stale VHD removed" ;
    }
}

Function AutoVMCopyFile
{
    param($Source, $Destination)
    AutoVMLogInfo "Copying $Source to $Destination";
    AutoVMPathExist -Path $Destination;
    Copy-Item $Source -Destination $Destination -Force  -ErrorAction Stop;
    AutoVMLogInfo "Copying done";
}

Function AutoVMCopyDirectory
{
    param($Source, $Destination)
    AutoVMLogInfo "Copying $Source to $Destination";
    AutoVMPathExist -Path $Destination;
    Copy-Item $Source -Destination $Destination -Force -Recurse  -ErrorAction Stop;
    AutoVMLogInfo "Copying done";
}

Function AutoVMCopyGeneralizedVHD
{
    param($Platform, $Destination);

    $config = $global:config;
    $sharepath = $config['vms'][$Platform];

    # Remove any other stale VHDs before copy
    AutoVMPathExistAndEmpty -Path $Destination -Filter "*.vhd";
    AutoVMCopyFile -Source $sharepath $Destination $Destination;

    #Create LastWriteTime Cookie
    $LastWriteTimeUtc = (Get-Item $sharepath).LastWriteTimeUtc.ToString($AutoVMDateFormat);
    Set-Content -Path "$($Destination)\cookie.txt" -Encoding "UTF8" -Force -Value $LastWriteTimeUtc;
}

Function AutoVMCreateEnlightenVHD
{
    param($Platform);
    $config = $global:config;

    AutoVMLogInfo "Enlightening VHD for $Platform Platform";

    $enlightenedvhdstore = $config['enlightenedvhdstore'];
    $enlightenedVhdDir = [io.path]::combine($enlightenedvhdstore, $Platform);
    AutoVMPathExistAndEmpty -Path $enlightenedVhdDir -Filter "*.vhd"
    # Copy generalized vhd from share first
    AutoVMCopyGeneralizedVHD -Platform $Platform -Destination $enlightenedVhdDir;

    $enlightenedVhd = (Get-ChildItem "$enlightenedVhdDir\*.vhd" -ErrorAction Stop)[0].FullName

    # Make sure mount directory exist
    $mountPoint = "$enlightenedVhdDir\mount";
    AutoVMPathExistAndEmpty -Path "$mountPoint" -Filter "*.*"

    AutoVMLogInfo "Mounting $enlightenedVhd to $mountPoint"
    $res = AutoVMMountVHDInternal -ImagePath $enlightenedVhd -MountPoint $mountPoint;
    if (-not $res) {AutoVMLogInfo "Mounting Error"; return;}
    AutoVMLogInfo "Mounting Done"

    # Copy any tools present in .\Tools\ to VHD Root
    $toolspath = $config['toolspath'];
    AutoVMLogInfo "Adding Tools from $toolspath to VHD @ $mountPoint\";
    AutoVMCopyDirectory -Source "$toolspath" -Destination "$mountPoint\";

    # Copy Unattend.xml to \Windows\Panther\Unattend. Which will be picked up by OOBE
    AutoVMCopyFile -Source "$mountPoint\Tools\Unattend.xml" -Destination "$mountPoint\Windows\Panther\Unattend";

    # Dismount the VHD
    AutoVMLogInfo "Unmounting $enlightenedVhd from $mountPoint";
    AutoVMDismountVHDInternal -ImagePath $enlightenedVhd -MountPoint $mountPoint;
    AutoVMLogInfo "Unmounting Done.";

    AutoVMLogInfo "Enlightened VHD: $enlightenedVhd";
}

Function AutoVMCheckIsEnlightenedVHDStale
{
    param($VHDPath, $Platform);
    $config = $global:config;

    AutoVMLogInfo "Checking for $VHDPath staleness for $Platform Platform";

    $cookie = "$(Split-Path $VHDPath -Parent)\cookie.txt";

    if (-not (Test-Path $cookie -PathType Leaf)) {
        AutoVMLogInfo "$cookie not found";
        return $True;
    }

    $lastWriteTimeUtcCookie = (Get-Content $cookie).Trim();
    if ([string]::IsNullOrEmpty($lastWriteTimeUtcCookie)) {
        AutoVMLogInfo "$cookie content is empty";
        return $True;
    }

    AutoVMLogInfo "Last last write time for $VHDPath is $lastWriteTimeUtcCookie";

    [datetime]$lastWriteTimeUtcCookie = [DateTime]::ParseExact(
                                                $lastWriteTimeUtcCookie,
                                                $AutoVMDateFormat,
                                                [System.Globalization.DateTimeFormatInfo]::InvariantInfo,
                                                [System.Globalization.DateTimeStyles]::None);

    $sharepath = $config['vms'][$Platform];
    [datetime]$lastWriteTimeUtc = (Get-Item $sharepath).LastWriteTimeUtc.ToString($AutoVMDateFormat);

    return ($lastWriteTimeUtcCookie -lt $lastWriteTimeUtc);
}

Function AutoVMEnlightenAllVHDs
{
    AutoVMPrintWarning "You are about to create enlightened VHD for all supported platforms. This could take around ~2Hours and ~300GB disk space..."  ;
    $choice = Read-Host "Would you like to continue?(Y/N)";
    if ($choice -ne "Y") {return;}

    $config = $global:config;
    $config["vms"].Keys | ForEach-Object {AutoVMCreateEnlightenVHD -Platform $_};
}

Function AutoVMGetVhdToSpinVM
{
    param($Platform);

    $config = $global:config;

    AutoVMLogInfo "Getting VHD to spin for VM $VMName on $Platform platform";

    # Try to make a copy of the enlightened vhd from $enlightenedvhdstore\$platform
    $enlightenedvhdstore = $config['enlightenedvhdstore'];
    $enlightenedVhdDir   = [io.path]::combine($enlightenedvhdstore, $Platform);
    $enlightenedVhd      = Get-ChildItem "$enlightenedVhdDir\*.vhd" -ErrorAction SilentlyContinue;
    if (-not $enlightenedVhd) {
        AutoVMLogWarning "Could not find VHD in $enlightenedVhdDir. Creating enlightened VHD first. This could take around ~20Mins..." ;
        AutoVMCreateEnlightenVHD -Platform $Platform;
    }
    elseif (AutoVMCheckIsEnlightenedVHDStale -VHDPath $($enlightenedVhd[0].FullName) -Platform $Platform) {
        AutoVMLogWarning "Previously cached englightened VHD $($enlightenedVhd[0].FullName) is stale compared to $($config['vms'][$Platform]). Fetching and recreating it would take around ~20Mins...";
        $choice = Read-Host "Would you like to continue?(Y/N)";
        if ($choice -eq "Y") {
            AutoVMCreateEnlightenVHD -Platform $Platform;
        }
    }
    $enlightenedVhd = Get-ChildItem "$enlightenedVhdDir\*.vhd" -ErrorAction Stop;
    $enlightenedVhd = $enlightenedVhd[0].FullName;

    Resize-VHD -Path $enlightenedVhd -SizeBytes 1TB  | Out-Null;

    return $enlightenedVhd;
}

Function AutoVMGetExternalSwitch
{
    $ExternalSwitch = Get-VMSwitch -SwitchType External;
    if (-not $ExternalSwitch) {
        AutoVMLogWarning "No external virtual switch found. Creating a new virtual switch 'AutoVM External Switch'..." ;
        $EthernetAdapaterName = (Get-NetAdapter | ? Status -eq Up | Sort-Object LinkSpeed | Select-Object -First 1).Name;
        if (-not $EthernetAdapaterName) {
            AutoVMLogInfo "No external Physical switch found to create virtual switch...Please make sure you have network adapater enabled";
        }
        $ExternalSwitch = New-VMSwitch -Name "AutoVM External Switch" -NetAdapterName  $EthernetAdapaterName -ErrorAction Stop;
    }
    return (Get-VMSwitch -SwitchType External)[0];
}

Function AutoVMGetPrivateSwitch
{
    $PrivateSwitch = Get-VMSwitch -SwitchType Private;
    if (-not $PrivateSwitch) {
        AutoVMLogWarning "No private virtual switch found. Creating a new virtual switch 'AutoVM Private Switch'..." ;
        $PrivateSwitch = New-VMSwitch -Name "AutoVM Private Switch" -SwitchType Private -ErrorAction Stop;
    }
    return (Get-VMSwitch -SwitchType Private)[0];
}

Function AutoVMPathExist
{
    param($Path)
    New-Item -ItemType Directory $Path -Force -ErrorAction Stop | Out-Null;
}

Function AutoVMPathExistAndEmpty
{
    param($Path, $Filter = "*.*")
    AutoVMPathExist -Path $Path;
    Remove-Item -Path "$Path\$Filter" -Force -ErrorAction Stop | Out-Null;
}

Function AutoVMCreateVMInternal
{
    param($VHDPath, $VMName)

    $config = $global:config;

    $ram = $config['ram'];
    $cores = $config['cores'];
    $vmconfigpath = $config['vmconfigpath'];
    AutoVMPathExist -Path $vmconfigpath;

    $ExternalSwitch = AutoVMGetExternalSwitch;
    #$PrivateSwitch  = AutoVMGetPrivateSwitch;

    AutoVMLogInfo "Creating VM $VMName...";
    # AutoVMLogInfo "New-VM -Name '$VMName' -MemoryStartupBytes $ram -BootDevice VHD -VHDPath '$vhdStoreVhd' -Path '$vmconfigpath' -Generation 1 -Switch '$($ExternalSwitch.Name)'";
    $vm = New-VM -Name "$VMName" -MemoryStartupBytes $ram -BootDevice VHD -VHDPath "$vhdStoreVhd" -Path "$vmconfigpath" -Generation 1 -Switch "$($ExternalSwitch.Name)";
    #Add-VMNetworkAdapter -VM $vm -SwitchName "$($PrivateSwitch.Name)";
    Set-VMProcessor -VMName $vm.Name -Count $cores;
    Set-VMMemory -VMName $vm.Name  -DynamicMemoryEnabled $true -MaximumBytes $ram;
    Set-VM -VM $vm  -CheckpointType Standard -AutomaticCheckpointsEnabled $False;

    AutoVMLogInfo "Creating VM Done.";
    return $vm;
}

Function AutoVMCreateNewVM
{
    param($Platform, $VMName);

    $config = $global:config;

    $vhdstore = $config['vhdstore'];
    AutoVMLogInfo "Creating VM with name $VMName for $Platform Platform";

    $vhdStoreVhdDir = [io.path]::combine($vhdstore, $Platform, $VMName);
    AutoVMPathExistAndEmpty -Path $vhdStoreVhdDir -Filter "*.vhd";
    $enlightenedVhd = AutoVMGetVhdToSpinVM -Platform $Platform;
    AutoVMLogInfo "Enlightend VM: $enlightenedVhd";
    AutoVMCopyFile -Source $enlightenedVhd -Destination $vhdStoreVhdDir;
    $vhdStoreVhd = (Get-ChildItem "$vhdStoreVhdDir\*.vhd" -ErrorAction Stop)[0].FullName;

    $vm = AutoVMCreateVMInternal -VHDPath $vhdStoreVhd -VMName $VMName;

    AutoVMLogInfo "Starting VM $VMName...";
    Start-VM -VM $vm | Out-Null;
    AutoVMLogInfo "Starting VM Done.";
}

Function AutoVMCreateScratchVHD
{
    param($VHDName);
    $config = $global:config;
    $scratchvhdpath = $config['scratchvhdpath'];

    $vhdSize = 600GB # Git enlistment should have atleast 512GB
    $vhdPath =  "$($scratchvhdpath)$($VHDName).vhdx"
    AutoVMLogInfo "Creating Scratch disk with name $VHDName";
    New-VHD -Path $vhdPath -SizeBytes $vhdSize -Dynamic | Out-Null
    AutoVMLogInfo "Mounting Scratch disk....";
    Mount-VHD -Path $vhdPath
    $disk = Get-Vhd -path $vhdPath
    Initialize-Disk $disk.DiskNumber
    AutoVMLogInfo "Formating Scratch disk....";
    $partition = New-Partition -AssignDriveLetter -UseMaximumSize -DiskNumber $disk.DiskNumber
    $volume = Format-Volume -FileSystem NTFS -Confirm:$false -Force -Partition $partition -NewFileSystemLabel $VHDName
    AutoVMLogInfo "Bitlocker encrypting Scratch disk....";
    Enable-BitLocker -MountPoint $volume.DriveLetter  -UsedSpaceOnly -RecoveryPasswordProtector -RecoveryPassword "111111-111111-111111-111111-111111-111111-111111-111111"
    Set-Content -Path "$($volume.DriveLetter):\CloneReadMe.txt" -Value $CloneReadMe
    AutoVMLogInfo "Adding drive to windows defender exclusion....";
    Add-MpPreference -ExclusionPath "$($volume.DriveLetter):\";
    #Dismount-VHD -Path $vhdPath
}


Function AutoVMPrintGeneralizedVHDs
{
    $config = $global:config;

    $platformColumnLength = ($config['vms'].Keys | Measure-Object -Property Length -Maximum).Maximum;
    $pathColumnLength = ($config['vms'].Values | Measure-Object -Property Length -Maximum).Maximum;

    AutoVMPrintInfo ("-" * ($platformColumnLength + $pathColumnLength + 3));
    AutoVMPrintInfo ("|{0,-$platformColumnLength}|{1,-$pathColumnLength}|" -f "Platform", "Vhd Path");
    AutoVMPrintInfo ("-" * ($platformColumnLength + $pathColumnLength + 3));
    foreach($platform in $config['vms'].Keys) {
        AutoVMPrintInfo ("|{0,-$platformColumnLength}|{1,-$pathColumnLength}|" -f $platform, $config['vms'][$platform]);
    }
    AutoVMPrintInfo ("-" * ($platformColumnLength + $pathColumnLength + 3));
    AutoVMPrintWarning "Shares starting with \\redmond may not contain the right vhd. This is our best bet right now."  ;
}

Function AutoVMCheckPrerequisites
{
    # Current user should be part of admin group
    $currentPrincipal = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent());
    if (!$currentPrincipal.IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
        AutoVMLogWarning "This script need to be run as admin/elevated. Good Bye"  ;
        return $False;
    }

    # Check Hyper-V is enabled
    $hyperV = Get-WindowsOptionalFeature -FeatureName Microsoft-Hyper-V-All -Online
    if ($hyperV.State -ne "Enabled") {
        AutoVMLogWarning "Hyper-V is not enabled. Good Bye"  ;
        return $False;
    }

    # SSD check

    # $config = $global:config;
    # $vhdStore = $config['vhdstore'];
    # $ssdDriveLetters = Get-PhysicalDisk | ? MediaType -eq SSD | Get-Disk | Get-Partition | ? DriveLetter | % DriveLetter;
    # if ($vhdStore[0] -ne "\" -and $vhdStore[0] -notin $ssdDriveLetters) {
    #     AutoVMLogWarning "vhdstore path $vhdStore is not on SSD drive. Update <vhdstore> in AutoVMConfig.xml to folder in SSD drive to speed up VM startup performance"  ;
    #     return $True;
    # }

    return $True;
}

<#
.SYNOPSIS

Creates a new VM with the specified name for the given platform

.DESCRIPTION

Creates a new VM with the specified name for the given platform.
It operates in two modes.
1. Non Interactive mode
2. Interactive mode

.PARAMETER Platform
Platform refers to the supported platforms for which a VM can be created

.INPUTS

None. You cannot pipe objects to New-AutoVM.

.OUTPUTS

None. New-AutoVM does not return anything.

.EXAMPLE
Non Interactive Mode:

PS> New-AutoVM -Platform 2016 -VMName RD_Server

.EXAMPLE
Interactive Mode:
PS> New-AutoVM
1. Create VM
2. Show RTM/Patched VHD locations
3. Create enlightended VHDs for all platforms
4. Remove Stale VHDs
5. Exit
Enter your choice:
#>
Function New-AutoVM {

    param($Platform, $VMName);

    AutoVMGetConfig

    if (!(AutoVMCheckPrerequisites)) {
        return $False;
    }

    if ($Platform -and $VMName) {
        AutoVMCreateNewVM -Platform $platform -VMName $vmname;
    }
    else {
        $config = $global:config;
        $platforms = $config['vms'].Keys -Join '|';
        while ($True) {
            AutoVMPrintInfo "1. Create VM";
            AutoVMPrintInfo "2. Create Scratch VHD";
            AutoVMPrintInfo "3. Remove Stale VHDs";
            AutoVMPrintInfo "4. Print Source VHD Paths";
            AutoVMPrintInfo "5. Exit";

            $choice = Read-Host "Enter your choice";
            switch ($choice) {
                1 {
                    $Platform = (Read-Host "Enter platform($platforms)").Trim();
                    if ($Platform -notin ($platforms -split "\|")) {
                        AutoVMLogWarning "Platform $Platform not supported..Try Again"  ;
                        break;
                    }
                    $VMName = (Read-Host "Enter VM name" ).Trim();
                    AutoVMCreateNewVM -Platform $Platform -VMName $VMName;
                    break;
                };
                2 {
                    $VHDName = Read-Host "Enter Scratch VHD name(no extension)";
                    AutoVMCreateScratchVHD -VHDName $VHDName;
                    break;
                };
                3 {
                    AutoVMRemoveStaleVhds;
                    break;
                };
                4 {
                    AutoVMPrintGeneralizedVHDs;
                    break;
                };
                Default {
                    return;
                }
            }
            AutoVMPrintInfo ("-" * 180);
        }
    }
}

