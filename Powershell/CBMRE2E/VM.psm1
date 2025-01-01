#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     VM.psm1
#
# Abstract:
#
#     This module implements the core routines for VM related operations
#
# Author:
#
#     Vineel Kovvuri (vineelko) 21-Feb-2022
#
# Environment:
#
#     User mode only.
#

Import-Module .\Logging.psm1
Import-Module .\VMScreenCapture.psm1
Import-Module .\Configuration.psm1
Import-Module .\Utilities.psm1
Import-Module .\VhdUtilities.psm1
Import-Module .\BuildDcat.psm1

Function CbmrGetExternalSwitch {
    $externalSwitch = Get-VMSwitch -SwitchType External
    if (-not $externalSwitch) {
        CbmrLogWarning "No external virtual switch found. Creating a new virtual switch 'Cbmr External Switch'..."
        $EthernetAdapaterName = (Get-NetAdapter | ? Status -eq Up | Sort-Object LinkSpeed | Select-Object -First 1).Name
        if (-not $EthernetAdapaterName) {
            CbmrLogInfo "No external Physical switch found to create virtual switch...Please make sure you have network adapater enabled"
        }
        $externalSwitch = New-VMSwitch -Name "Cbmr External Switch" -NetAdapterName  $EthernetAdapaterName
    }
    return (Get-VMSwitch -SwitchType External)[0]
}

enum FirstBoot {
    HDD
    UefiShell
}

Function CbmrChangeFirstBoot
{
    param($VM, [FirstBoot]$FirstBoot)

    $fw = Get-VMFirmware -VM $VM

    if ($FirstBoot -eq [FirstBoot]::HDD) {
        $disk = $fw.BootOrder | ? {$_.FirmwarePath.Contains("Scsi(0,0)")}
    }
    else {
        $disk = $fw.BootOrder | ? {$_.FirmwarePath.Contains("Scsi(0,1)")}  # Get UEFI Shell Vhdx
    }
    Set-VMFirmware -VM $VM -FirstBootDevice $disk

    CbmrLogInfo "Changing VM $($VM.Name) boot order done."
}

# CbmrChangeFirstBoot -VM $VM -BootOrder HDD

# Copy file from \\winbuilds only if we cannot find a local copy
Function CbmrCopyVhdx
{
    param($VhdBuildDirectory, $VhdStore)

    $srcVHDPath = (Get-ChildItem "$VhdBuildDirectory\*.vhdx").FullName
    $vhdName = CbmrGetFileName -Path $srcVHDPath

    $backupPath = "$VhdStore\backup"
    CbmrEnsurePathExist $backupPath

    $backupVHDPath = "$backupPath\$vhdName"
    if (Test-Path $backupVHDPath) { # Copy from \\winbuilds
        CbmrLogInfo "Copying $backupVHDPath to $VhdStore"
        CbmrCopyFile -SourceFile $backupVHDPath -DestinationDirectory $VhdStore
    } else { # Use a local copy
        CbmrLogInfo "Copying $srcVHDPath to $backupPath"
        CbmrCopyFile -SourceFile $srcVHDPath -DestinationDirectory $backupPath
        CbmrCopyFile -SourceFile "$backupPath\$vhdName" -DestinationDirectory $VhdStore
    }

    return "$VhdStore\$vhdName"
}

Function CbmrDeleteExistingVM
{
    param($VmName)

    $vm = Get-VM -Name $VmName -ErrorAction SilentlyContinue

    if (-not $vm) {
        return
    }

    CbmrStopVM -VM $vm

    for ($i = 0; $i -lt 15; $i++) {
        if ($vm.State -eq "Off") {
            break;
        }

        Start-Sleep -Seconds 5
    }

    Get-VMHardDiskDrive -VM $vm | % { Remove-Item -Path $_.Path}

    $vmconfigpath = "$($vm.Path)\Virtual Machines"
    Remove-Item -Path "$vmconfigpath\$($VM.Name)_si.wim" -ErrorAction SilentlyContinue
    Remove-Item -Path "$vmconfigpath\*.log" -ErrorAction SilentlyContinue
    Remove-Item -Path "$vmconfigpath\*.bmp" -ErrorAction SilentlyContinue
    Remove-VM -VM $vm -Force
}

Function CbmrCreateVM {
    $config = CbmrReadConfig
    $memory = $config['memory']
    $cores = $config['cores']
    $vmconfigpath = $config['vmconfigpath']

    CbmrLogInfo "Finding the build to pick..."
    $winbuildDirectory = CbmrGetBuildDirectory
    $vhdBuildDirectory = "$($winbuildDirectory)\amd64fre\vhdx\vhdx_client_enterprise_en-us_vl"

    if (-not (Test-Path $vhdBuildDirectory)) {
        throw "$vhdBuildDirectory do not exist"
    }

    $srcVHDPath = (Get-ChildItem "$VhdBuildDirectory\*.vhdx").FullName
    $vhdName = CbmrGetFileName -Path $srcVHDPath

    $buildString = $(CbmrGetFileNameWithoutExtension -Path $vhdName)
    $vmName = "CBMR_$buildString"

    # Delete any existing VM with the same name
    CbmrDeleteExistingVM -VmName $vmName

    $vmstore = "$vmconfigpath\$vmName\Virtual Machines"
    CbmrEnsurePathExist -Path $vmstore

    $config["vmstore"] = $vmstore

    $vhdPath = CbmrCopyVhdx -VhdBuildDirectory $vhdBuildDirectory -VhdStore $vmstore

    CbmrEnlightenVHD -VHDPath $vhdPath

    $externalSwitch = CbmrGetExternalSwitch
    CbmrLogInfo "Creating VM $vmName..."
    $vm = New-VM -Name "$vmName"                        `
                 -MemoryStartupBytes $memory            `
                 -BootDevice VHD                        `
                 -VHDPath "$vhdPath"                    `
                 -Path "$vmconfigpath"                  `
                 -Generation 2                          `
                 -SwitchName "$($externalSwitch.Name)"

    Set-VM -VM $vm  -CheckpointType Disabled -AutomaticCheckpointsEnabled $False
    Set-VMFirmware -VM $vm -EnableSecureBoot Off
    Set-VMMemory -VMName $vm.Name  -DynamicMemoryEnabled $False -StartupBytes  $memory
    Set-VMProcessor -VMName $vm.Name -Count $cores
    Set-VMNetworkAdapter -VMName $vm.Name -PortMirroring Source
    #Set-VMComPort -VMName $vm.Name -Path \\.\pipe\bootmgfw -Number 1

    # Create and attach UEFI Shell VHD. This gets attached at Scsi(0, 1)
    $uefiShellVhd = CbmrCreateUEFIShellVHD -VM $vm -WinBuildDirectory $winbuildDirectory -VhdName "CBMR_$($buildString)_uefishell.vhdx"
    Add-VMHardDiskDrive -VM $vm -Path $uefiShellVhd

    CbmrLogInfo "Creating VM Done."
    return $vm
}

Function CbmrStartVM
{
    param($VM)

    Start-VM -VM $VM | Out-Null
    Start-Sleep -Seconds 5
    CbmrLogInfo "Starting VM $($VM.Name) Done."
}

Function CbmrStopVM
{
    param($VM)

    Stop-VM -VM $VM -TurnOff | Out-Null
    CbmrLogInfo "Stoping VM $($VM.Name) Done."
}

Function CbmrCreateUEFIShellVHD {

    param($VM, $WinBuildDirectory, $VhdName)

    $scriptRoot = CbmrScriptRoot
    $config = CbmrReadConfig
    $vmconfigpath = $config['vmconfigpath']
    $vmstore = "$vmconfigpath\$($VM.Name)\Virtual Machines"
    $cbmrconfigfilepath = $config['cbmrconfigfilepath']

    # Create VHD and Format as FAT32
    $vhdSize = 2GB
    $vhdPath = "$vmstore\$($VhdName)"

    CbmrLogInfo "Creating UEFI Shell disk with name $VhdName"
    Remove-Item $vhdPath -ErrorAction SilentlyContinue | Out-Null
    New-VHD -Path $vhdPath -SizeBytes $vhdSize -Dynamic | Out-Null

    CbmrLogInfo "Mounting/Formatting UEFI Shell disk...."
    CbmrMountVhd -VhdPath $VhdPath
    $driveLetter = CbmrFormatVhd -VhdPath $vhdPath

    # Copy Standard UEFI Collaterals
    CbmrLogInfo "Copying standard UEFI collaterals to $vhdPath...."
    CbmrCopyDirectory -SourceDirectory "$scriptRoot\UEFICollaterals" -DestinationDirectory "$($driveLetter):\"

    # Copy UEFI CBMR Binaries
    CbmrLogInfo "Copying CBMR binaries to $vhdPath...."
    # CbmrCopyFile -SourceFile "$($WinbuildDirectory)\amd64fre\bin\windbgserver.efi" -DestinationDirectory "$($driveLetter):\"
    #CbmrCopyFile -SourceFile "$($WinbuildDirectory)\amd64fre\bin\cbmr_app_debug.efi" -DestinationDirectory "$($driveLetter):\"
    #CbmrCopyFile -SourceFile "$($WinbuildDirectory)\amd64fre\bin\cbmr_driver_debug.efi" -DestinationDirectory "$($driveLetter):\"

    CbmrCopyFile -SourceFile "\\winbuilds\release\rs_fun_deploy_dev2\25317.1000.230310-1600\amd64fre\bin\cbmr_app_debug.efi" -DestinationDirectory "$($driveLetter):\"
    CbmrCopyFile -SourceFile "\\winbuilds\release\rs_fun_deploy_dev2\25317.1000.230310-1600\amd64fre\bin\cbmr_driver_debug.efi" -DestinationDirectory "$($driveLetter):\"

    Copy-Item  "$cbmrconfigfilepath" -Destination "$($driveLetter):\cbmr_config.txt"

    CbmrDismountVhd -VhdPath $vhdPath

    return $vhdPath
}

Function CbmrEnlightenVHD {
    param($VHDPath)

    $scriptRoot = CbmrScriptRoot

    CbmrLogInfo "Enlightening VHD $VHDPath "

    CbmrLogInfo "Mounting $VHDPath"
    CbmrMountVhd -VhdPath $VHDPath
    $driveLetter = CbmrGetMountedVhdDriveLetter -VhdPath $VHDPath

    # Copy Unattend.xml to \Windows\Panther\Unattend. Which will be picked up by OOBE to create Admin account
    # A user account is needed later to use Powershell Direct and export Software Inventory
    CbmrCopyFile -Source "$scriptRoot\SiCollaterals\Unattend.xml" -Destination "$($driveLetter):\Windows\Panther\Unattend"
    CbmrCopyFile -Source "$scriptRoot\SiCollaterals\diskpart.s" -Destination "$($driveLetter):\"
    CbmrCopyFile -Source "$scriptRoot\SiCollaterals\ResetConfig.xml" -Destination "$($driveLetter):\"

    CbmrDismountVhd -VhdPath $VHDPath
}

Function CbmrCaptureSoftwareInventory
{
    param($VM)

    $config = CbmrReadConfig
    $build = $config['build']
    $endpointtype = $config['endpointtype']
    $build = $config['build']
    $startTime = $config['starttime']
    $branch = $config['branch']

    CbmrLogInfo "Capturing Software Inventory from $($VM.Name)..."
    $password = ConvertTo-SecureString 'Test@123' -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ('~\Administrator', $password)

    # Powershell Direct to the rescue!
    $vmSession = New-PSSession -VMName $($VM.Name) -Credential $credential
    Invoke-Command -Session $vmSession { New-Item -ItemType Directory "C:\Temp" -ErrorAction SilentlyContinue | Out-Null}

    # Capture si.wim
    Invoke-Command -Session $vmSession { dism /online /Capture-SoftwareInventory /partitioning-script:c:\diskpart.s /reset-config-xml:c:\ResetConfig.xml /Output-Directory:C:\Temp}

    # Copy it locally. Useful for validating on hardware
    $logpath = "$($config['logpath'])\$branch\$endpointtype\$build\$($startTime.ToString('yyMMdd-hhmmss'))"
    CbmrEnsureDirectoryExistAndEmpty -Path $logpath
    Copy-Item -FromSession $vmSession -Path "C:\temp\si.wim" -Destination "$logpath\si.wim"
    Remove-PSSession -Session $vmSession
    # Rename-Item -Path "$vmstore\si.wim" -NewName "$vmstore\$($VM.Name)_si.wim" -ErrorAction SilentlyContinue | Out-Null
}

Function CbmrDeleteVM
{
    param($VM)

    CbmrLogInfo "Stopping and deleting the VM $($VM.Name)"

    CbmrStopVM -VM $vm

    for ($i = 0; $i -lt 15; $i++) {
        if ($vm.State -eq "Off") {
            break;
        }

        Start-Sleep -Seconds 5
    }

    Get-VMHardDiskDrive -VM $vm | % { Remove-Item -Path $_.Path}
    Remove-VM -VM $vm -Force
}
