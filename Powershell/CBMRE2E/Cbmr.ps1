#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     Cbmr.ps1
#
# Abstract:
#
#
#  ██████╗    ██████╗     ███╗   ███╗    ██████╗
# ██╔════╝    ██╔══██╗    ████╗ ████║    ██╔══██╗
# ██║         ██████╔╝    ██╔████╔██║    ██████╔╝
# ██║         ██╔══██╗    ██║╚██╔╝██║    ██╔══██╗
# ╚██████╗    ██████╔╝    ██║ ╚═╝ ██║    ██║  ██║
#  ╚═════╝    ╚═════╝     ╚═╝     ╚═╝    ╚═╝  ╚═╝
#
#         ███████╗    ██████╗     ███████╗
#         ██╔════╝    ╚════██╗    ██╔════╝
#         █████╗       █████╔╝    █████╗
#         ██╔══╝      ██╔═══╝     ██╔══╝
#         ███████╗    ███████╗    ███████╗
#         ╚══════╝    ╚══════╝    ╚══════╝
#
#
# Author:
#
#     Vineel Kovvuri (vineelko) 17-Feb-2022
#
# Environment:
#
#     User mode only.
#
#
# cmdkey /generic:cbmrcreds /user:redmond\vineelko /pass:xxxxxxxx

param ($VHDPath, $VMName)

$ErrorActionPreference = "Stop"

Import-Module .\Logging.psm1
Import-Module .\Configuration.psm1
Import-Module .\Utilities.psm1
Import-Module .\VM.psm1
Import-Module .\VMScreenCapture.psm1
Import-Module .\VMKeyboard.psm1
Import-Module .\VhdUtilities.psm1
Import-Module .\Prerequisites.psm1


Function CbmrShowBanner {
    $scriptRoot = CbmrScriptRoot
    Get-Content "$($scriptRoot)\logo.txt" | Write-Host
}

Function CbmrWaitForDesktop {
    param($VM)

    $desktopLaunched = $False

    CbmrLogInfo "Waiting for desktop to be launched...."
    $i = 0
    $password = ConvertTo-SecureString 'Test@123' -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ('~\Administrator', $password)
    while ($True) {
        try {
            $explorer = Invoke-Command -VMName $($VM.Name) -ScriptBlock { (Get-Process -Name "explorer" -ErrorAction SilentlyContinue)} -Credential $credential -ErrorAction SilentlyContinue
            if ($explorer) {
                $startTime = $explorer[0].StartTime
                $timeSpan = New-TimeSpan -Start $startTime -End (Get-Date)
                if ($timeSpan.Minutes -ge 5) {
                    CbmrLogInfo "Desktop launched"
                    $desktopLaunched = $True
                    break
                }
            }
        } catch {}

        Start-Sleep -Seconds 5
        if (($i * 5) -gt (25 * 60)) { # 25 Minutes
            # Some times the explorer is crashing repeatedly. If this is the case
            # the presence of explorer process is considered as desktop launched
            # instead checking for its start time > 5 mins like above
            try {
                $explorer = Invoke-Command -VMName $($VM.Name) -ScriptBlock { (Get-Process -Name "explorer" -ErrorAction SilentlyContinue)} -Credential $credential
                if ($explorer) {
                    CbmrLogInfo "Desktop launched"
                    $desktopLaunched = $True
                    break
                }
            } catch {}

            CbmrLogInfo "Desktop could not be launched in expected time!"
            $desktopLaunched = $False
            break
        }
        $i++
    }

    return $desktopLaunched
}

Function CbmrWaitForOOBE {
    param($VM)

    $oobeLaunched = $False
    # Sample pixels from Win 11 OOBE screen and their associated color data
    $oobeBmpSignature = @(
        @(  0,   0, "ff180000"),
        @(100, 100, "fff7fbff"),
        @(200, 200, "fff7fbff"),
        @(300, 300, "ffeff7ff"),
        @(400, 400, "ffeff3ff"),
        @(500, 500, "ffeff3ff"),
        @(600, 600, "ffefeff7"),
        @(700, 700, "ffeff3ff")
    )
    $timeout = 3 # Minutes

    CbmrLogInfo "Waiting for OOBE to be launched...."
    $i = 0
    $prevBitMap = $null
    while ($True) {
        $currentBitMap = CbmrCaptureVMScreen -VMName "$($VM.Name)"
        if ((CbmrCompareBitMapSignature -BitMap $currentBitMap -Signature $oobeBmpSignature)) {
            CbmrLogInfo "OOBE launched"
            $currentBitMap.Dispose()
            $oobeLaunched = $True
            break
        }

        # Check if the screen did not change even after one minute. This is a
        # sign for no progress and possibly a failure
        if ($prevBitMap) {
            $result = CbmrExactImageCompare -BitMap1 $prevBitMap -BitMap2 $currentBitMap
            $prevBitMap.Dispose()
            if ($result) {
                CbmrLogInfo "No progress observed in the last $timeout minutes. Most likely a failure"
                $oobeLaunched = $False
                break;
            }
        }

        if ($i -gt 10) { # 10 * 3 Minutes
            CbmrLogInfo "OOBE could not be launched in expected time!"
            $oobeLaunched = $False
            $prevBitMap.Dispose()
            $currentBitMap.Dispose()
            break
        }

        $prevBitMap = $currentBitMap
        $i++
        Start-Sleep -Seconds ($timeout*60)
    }

    return $oobeLaunched
}

Function CbmrHandleFailuresInUEFI {
    param($VM)

    $config = CbmrReadConfig
    $branch = $config['branch']
    $endpointtype = $config['endpointtype']
    $build = $config['build']
    $startTime = $config['starttime']
    $emailto = $config['emailto']
    $logpath = "$($config['logpath'])\$branch\$endpointtype\$build\$($startTime.ToString('yyMMdd-hhmmss'))"

    # Step 1: Capture the screen shot
    $vmScreenBmp = CbmrCaptureVMScreen -VMName "$($VM.Name)"
    $vmScreenBmp.Save("$logpath\screenshot_uefi.bmp")
    $vmScreenBmp.Dispose();
    CbmrLogInfo "Copied VM UEFI Screenshot to $logpath"

    # Step 2: Copy the logs
    CbmrStopVM -VM $VM
    $uefiShellVhd = (Get-VMHardDiskDrive -VM $vm | ? { $_.Path.Contains("uefishell")}).Path
    CbmrMountVhd -VhdPath $uefiShellVhd
    $driveLetter = CbmrGetMountedVhdDriveLetter -VhdPath $uefiShellVhd
    Copy-Item "$($driveLetter):\*.log" $logpath
    CbmrDismountVhd -VhdPath $uefiShellVhd
    CbmrLogInfo "Copied UEFI logs to $logpath"

    # Step 3: Send E-mail
    try {
        # For below code to work make sure Outlook is not running. Because below
        # code will fail to communicate with Outlook COM API if it is already
        # running as standard user and since the script is running as elevated.
        $outlook = New-Object -ComObject Outlook.Application
        $email = $outlook.CreateItem(0)
        $email.To = $emailto
        $email.Subject = "CBMR E2E failed for $branch|$build|$endpointtype at $($startTime.ToString('MM/dd/yyyy-hh:mm:ss')) "
        Get-ChildItem "$logpath\*.log" | % {$email.Attachments.add($_.FullName) | Out-Null}
        $screenshot = (Get-ChildItem "$logpath\screenshot_uefi.bmp").FullName
        $imageContentId = "screenshot_uefi"
        $screenshotAttachment = $email.Attachments.add($screenshot, [Microsoft.Office.Interop.Outlook.OlAttachmentType]::olByValue, $null, "VM Screenshot")
        $screenshotAttachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", $imageContentId);
        $email.HTMLBody =
@"
            <b>VM Name:</b> $($VM.Name)<br/>
            <b>Branch:</b> $branch<br/>
            <b>Build:</b> $build<br/>
            <b>DCAT Environment:</b> $($endpointtype.ToUpper())<br/>
            <b>Host Name:</b> $($env:COMPUTERNAME) <br/>
            <b>User Name:</b> $env:UserDomain\$env:UserName <br/>
            <b>Logs:</b> <a href="$logpath">$logpath</a><br/>
            <b>Start Time:</b> $($startTime.ToString('MM/dd/yyyy-hh:mm:ss'))<br/>
            <img src='cid:$imageContentId'/><br/>
"@
        $email.Send()
        $outlook.Quit()
    } catch {
        CbmrLogInfo "Unable to send email. Please find the logs and screenshot at $logpath"
    }
}

Function CbmrHandleFailuresInStubOS {
    param($VM)

    $config = CbmrReadConfig
    $branch = $config['branch']
    $endpointtype = $config['endpointtype']
    $build = $config['build']
    $startTime = $config['starttime']
    $emailto = $config['emailto']
    $logpath = "$($config['logpath'])\$branch\$endpointtype\$build\$($startTime.ToString('yyMMdd-hhmmss'))"

    # Step 1: Capture the screen shot
    $vmScreenBmp = CbmrCaptureVMScreen -VMName "$($VM.Name)"
    $vmScreenBmp.Save("$logpath\screenshot_stubos.bmp")
    $vmScreenBmp.Dispose();
    CbmrLogInfo "Copied VM StubOS Screenshot to $logpath"

    # Step 2: Copy the logs
    # Try to get domain creds from Windows Credential Manager
    $username = (Get-StoredCredential -Target 'cbmrcreds').UserName
    $securedPassword = (Get-StoredCredential -Target 'cbmrcreds').Password
    if (!$username -or !$securedPassword) { # if failed then prompt for credentials
        CbmrLogInfo "Could not find domain credentials in Credential Manager"
        CbmrLogInfo "Please save them with 'cmdkey /generic:cbmrcreds /user:domain\username /pass:xxxxxxxx' for touch free experience!"
        $username = Read-Host -Prompt "Enter domain user name(domain\username)"
        $securedPassword = Read-Host -Prompt "Enter password" -AsSecureString
    }

    $bstr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($securedPassword)
    $password = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($bstr)

    CbmrVMKeyboardSendKey -VMName $($VM.Name) -Key $global:F10Key -ShiftOrControl $global:ShiftKey
    Start-Sleep -Seconds 2
    CbmrVMKeyboardTypeTextWithNewLine -VMName $($VM.Name) -Text "net use $logpath"
    Start-Sleep -Seconds 2
    CbmrVMKeyboardTypeTextWithNewLine -VMName $($VM.Name) -Text $username
    Start-Sleep -Seconds 2
    CbmrVMKeyboardTypeTextWithNewLine -VMName $($VM.Name) -Text $password
    Start-Sleep -Seconds 2
    CbmrVMKeyboardTypeTextWithNewLine -VMName $($VM.Name) -Text "xcopy /Q /Y X:\`$SysReset\Logs\setupact.log $logpath\Xsetupact.log*"
    Start-Sleep -Seconds 2
    CbmrVMKeyboardTypeTextWithNewLine -VMName $($VM.Name) -Text "xcopy /Q /Y W:\`$SysReset\Logs\setupact.log $logpath\Wsetupact.log*"
    Start-Sleep -Seconds 2

    # Step 3: Send E-mail
    try {

        # For below code to work make sure Outlook is not running. Because below
        # code will fail to communicate with Outlook COM API if it is already
        # running as standard user and since the script is running as elevated.
        $outlook = New-Object -ComObject Outlook.Application
        $email = $outlook.CreateItem(0)
        $email.To = $emailto
        $email.Subject = "CBMR E2E failed for $branch|$build|$endpointtype at $($startTime.ToString('MM/dd/yyyy-hh:mm:ss')) "
        Get-ChildItem "$logpath\*.log" | % {$email.Attachments.add($_.FullName) | Out-Null}
        $screenshot = (Get-ChildItem "$logpath\screenshot_stubos.bmp").FullName
        $imageContentId = "screenshot_stubos"
        $screenshotAttachment = $email.Attachments.add($screenshot, [Microsoft.Office.Interop.Outlook.OlAttachmentType]::olByValue, $null, "VM Screenshot")
        $screenshotAttachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", $imageContentId);
        $email.HTMLBody =
@"
            <b>VM Name:</b> $($VM.Name)<br/>
            <b>Branch:</b> $branch<br/>
            <b>Build:</b> $build<br/>
            <b>DCAT Environment:</b> $($endpointtype.ToUpper())<br/>
            <b>Host Name:</b> $($env:COMPUTERNAME) <br/>
            <b>User Name:</b> $env:UserDomain\$env:UserName <br/>
            <b>Logs:</b> <a href="$logpath">$logpath</a><br/>
            <b>Start Time:</b> $($startTime.ToString('MM/dd/yyyy-hh:mm:ss'))<br/>
            <img src='cid:$imageContentId'/><br/>
"@
        $email.Send()
        $outlook.Quit()
    } catch {
        CbmrLogInfo "Unable to send email. Please find the logs and screenshot at $logpath"
    }
}

Function CbmrHandleSuccess {
    param($VM)

    $config = CbmrReadConfig
    $branch = $config['branch']
    $endpointtype = $config['endpointtype']
    $build = $config['build']
    $startTime = $config['starttime']
    $emailto = $config['emailto']
    $logpath = "$($config['logpath'])\$branch\$endpointtype\$build\$($startTime.ToString('yyMMdd-hhmmss'))"

    # Step 1: Capture the screen shot
    $vmScreenBmp = CbmrCaptureVMScreen -VMName "$($VM.Name)"
    $vmScreenBmp.Save("$logpath\screenshot_oobe.bmp")
    $vmScreenBmp.Dispose();
    CbmrLogInfo "Copied VM OOBE Screenshot to $logpath"

    # Step 2: Should we also capture the success logs? How?

    # Step 3: Send E-mail
    try {

        # For below code to work make sure Outlook is not running. Because below
        # code will fail to communicate with Outlook COM API if it is already
        # running as standard user and since the script is running as elevated.
        $outlook = New-Object -ComObject Outlook.Application
        $email = $outlook.CreateItem(0)
        $email.To = $emailto
        $email.Subject = "CBMR E2E succeeded for $branch|$build|$endpointtype at $($startTime.ToString('MM/dd/yyyy-hh:mm:ss')) "
        #Get-ChildItem "$logpath\*.log" | % {$email.Attachments.add($_.FullName) | Out-Null}
        $screenshot = (Get-ChildItem "$logpath\screenshot_oobe.bmp").FullName
        $imageContentId = "screenshot_oobe"
        $screenshotAttachment = $email.Attachments.add($screenshot, [Microsoft.Office.Interop.Outlook.OlAttachmentType]::olByValue, $null, "VM Screenshot")
        $screenshotAttachment.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", $imageContentId);
        $email.HTMLBody =
@"
            <b>VM Name:</b> $($VM.Name)<br/>
            <b>Branch:</b> $branch<br/>
            <b>Build:</b> $build<br/>
            <b>DCAT Environment:</b> $($endpointtype.ToUpper())<br/>
            <b>Host Name:</b> $($env:COMPUTERNAME) <br/>
            <b>User Name:</b> $env:UserDomain\$env:UserName <br/>
            <b>Logs:</b> <a href="$logpath">$logpath</a><br/>
            <b>Start Time:</b> $($startTime.ToString('MM/dd/yyyy-hh:mm:ss'))<br/>
            <img src='cid:$imageContentId'/><br/>
"@
        $email.Send()
        $outlook.Quit()
    } catch {
        CbmrLogInfo "Unable to send email. Please find the logs and screenshot at $logpath"
    }
}

Function CbmrHandleFailures {
    param($VM)

    # Sample the color of the screen at (1, 1) to determine if we failed in UEFI
    # or StubOS. This is not a great way to find where we failed but it works
    # for now! Black indicate UEFI and Blue indicate StubOS!
    $vmScreenBmp = CbmrCaptureVMScreen -VMName "$($VM.Name)"
    $colorValue = $vmScreenBmp.GetPixel(1, 1).Name
    $vmScreenBmp.Dispose()

    if ($colorValue -eq "ff000000") {        # Black
        CbmrHandleFailuresInUEFI -VM $VM
        CbmrLogInfo "CBMR E2E failed in UEFI"
    } elseif ($colorValue -eq "ff2165b5") {  # Blue
        CbmrHandleFailuresInStubOS -VM $VM
        CbmrLogInfo "CBMR E2E failed in StubOS"
    } else {
        CbmrLogInfo "CBMR E2E failed. Unrecognized phase colorValue=$colorValue"
    }
}

Function CbmrStartTSharkTrace {
    param($VM)

    $config = CbmrReadConfig
    $vmstore = $config["vmstore"]

    # get the VM's adapater and its associated switch name
    $vmAdapater = Get-VMNetworkAdapter -VM $VM
    $switchName = $vmAdapater.SwitchName

    # get the management OS adapater and set it as port mirroring destination
    $managementOsAdapater = Get-VMNetworkAdapter -ManagementOS | ? {$_.Name -eq "$switchName"}
    Set-VMNetworkAdapter -VMNetworkAdapter $managementOsAdapater -PortMirroring Destination

    # get the management OS adapater interface name in host OS. Which will be 'vEthernet ($switchName)'
    $managementOsAdapaterInterfaceName = (Get-NetAdapter | ? {$_.Name.Contains($switchName)}).Name

    # remove old/stale pcap files if any
    Remove-Item -Path "$vmstore\capture-output*.pcap" -Force  | Out-Null

    # create 200MB trace files
    $tsharkProcess = Start-Process -FilePath "$env:SYSTEMDRIVE\Program Files\Wireshark\tshark.exe" -ArgumentList "-i `"$managementOsAdapaterInterfaceName`"",  "-w `"$vmstore\capture-output.pcap`"", "-b filesize:200000"  -PassThru

    return $tsharkProcess;
}

Function CbmrStopTSharkTrace {
    param($TSharkProcess, $DeleteTraceFile)

    $config = CbmrReadConfig
    $vmstore = $config["vmstore"]

    $branch = $config['branch']
    $endpointtype = $config['endpointtype']
    $build = $config['build']
    $startTime = $config['starttime']
    $tracepath = "$($config['logpath'])\$branch\$endpointtype\$build\$($startTime.ToString('yyMMdd-hhmmss'))"

    # Luckily tshark gets launched in a new cmd window and below is the only
    # safest way to terminate the process instead of calling Stop-Process. This
    # is equivalent to sending Ctrl+C.
    $TSharkProcess.CloseMainWindow();

    Start-Sleep 5
    if (-not $DeleteTraceFile) { # copy them to share
        Copy-Item "$vmstore\capture-output*.pcap" $tracepath
    }

    # Remove-Item -Path "$vmstore\capture-output*.pcap" -Force  | Out-Null
}

Function CbmrE2EMain {
    $scriptRoot = CbmrScriptRoot
    $config = CbmrReadConfig
    $branch = $config['branch']
    $endpointtype = $config['endpointtype']
    $config['starttime'] = Get-Date

    #
    # Check prerequisites
    #

    if (!(CbmrCheckPrerequisites)) {
        return $False
    }

    CbmrLogInfo "Performing CBMR E2E $branch|$endpointtype"

    #
    # Spin a new VM and launch it
    #

    $vm = CbmrCreateVM
    CbmrStartVM -VM $vm

    #
    # Capture SI once desktop is launched
    #

    $desktopLaunched = CbmrWaitForDesktop -VM $vm
    if (!$desktopLaunched) {
        return $False
    }

    #$vm = Get-VM -Name "25057.1002.amd64fre.rs_fun_deploy_t4.220223-1754_client_enterprise_en-us_vl"
    CbmrCaptureSoftwareInventory -VM $vm

    #
    # Stop the VM, Change the boot order to UEFI disk, resize OS disk
    #

    CbmrStopVM -VM $vm
    CbmrChangeFirstBoot -VM $vm -FirstBoot UefiShell
    CbmrResizeAndClearOsVhd -VM $vm

    # $TSharkProcess = CbmrStartTSharkTrace -VM $vm

    #
    # Start the VM with UEFI Shell as the primary disk
    #

    CbmrStartVM -VM $vm

    #
    # Wait for OOBE to be launched
    #

    $oobeLaunched = CbmrWaitForOOBE -VM $vm
    if ($oobeLaunched) {
        CbmrHandleSuccess -VM $vm
        CbmrLogInfo "Success CBMR E2E done"
    } else {
        CbmrHandleFailures -VM $vm
    }

    #
    # Torn down the VM
    #

    if ($oobeLaunched) {
        CbmrDeleteVM -VM $vm
    }

    # CbmrStopTSharkTrace -TSharkProcess $TSharkProcess -DeleteTraceFile $oobeLaunched

    return $oobeLaunched
}


CbmrShowBanner

CbmrLogInfo "=============================================================="

$scriptRoot = CbmrScriptRoot
$cbmrcontinue = $true
while ($cbmrcontinue) {
    Get-ChildItem "$scriptRoot\Configs\*.xml" | % {
        CbmrSetConfigFile -ConfigFile $_.FullName
        $config = CbmrReadConfig
        $enabled = $config['enabled']

        if ($enabled -eq "false") {
            return;
        }

        $cbmrcontinue = CbmrE2EMain
        # $config = CbmrReadConfig
        # $config['build'] = '22572.1.220304-1536'
        # $config['starttime'] = Get-Date
        # $vm = Get-VM  "CBMR_22572.1.amd64fre.ni_release.220304-1536_client_enterprise_en-us_vl"
        # CbmrHandleFailuresInStubOS -VM $vm
        CbmrLogInfo "=============================================================="
    }
}
