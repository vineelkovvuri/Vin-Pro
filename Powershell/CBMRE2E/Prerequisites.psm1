#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     Prerequisites.psm1
#
# Abstract:
#
#     This module implements CBMR E2E logic to check for prerequisites
#
# Author:
#
#     Vineel Kovvuri (vineelko) 25-Feb-2022
#
# Environment:
#
#     User mode only.
#

Function CbmrCheckPrerequisites
{
    $config = CbmrReadConfig

    CbmrLogInfo "Checking prerequisites...."

    $isAdmin = [bool](([System.Security.Principal.WindowsIdentity]::GetCurrent()).groups -match "S-1-5-32-544")
    if (!$isAdmin) {
        CbmrLogInfo "Launch the script elevated(as admin)"
        return $False
    }

    $ram = $config['ram']
    $freePhysicalMemory = ((Get-CIMInstance Win32_OperatingSystem).FreePhysicalMemory * 1KB)/1GB
    if ($freePhysicalMemory -le $ram) {
        CbmrLogInfo "Not enough ram $freePhysicalMemory wanted atleast $ram"
        return $False
    }

    $vmconfigpath = $config['vmconfigpath']
    $driveLetter = [System.IO.Path]::GetPathRoot($vmconfigpath)
    $freeDriveSpace = (Get-CIMInstance Win32_LogicalDisk  | ? {$driveLetter.StartsWith($_.Name)}).FreeSpace/1GB
    if ($freeDriveSpace -le 20) {  # 20 GB
        CbmrLogInfo "Not enough disk space $freeDriveSpace wanted atleast 20GB"
        return $False
    }

    $username = (Get-StoredCredential -Target 'cbmrcreds').UserName
    $securedPassword = (Get-StoredCredential -Target 'cbmrcreds').Password
    if (!$username -or !$securedPassword) { # if failed then prompt for credentials
        CbmrLogInfo "Could not find domain credentials in Credential Manager"
        CbmrLogInfo "Please save them with 'cmdkey /generic:cbmrcreds /user:domain\username /pass:xxxxxxxx' for touch free experience!"
        return $False
    }

    $hyperv = Get-WindowsOptionalFeature -FeatureName Microsoft-Hyper-V-All -Online
    if($hyperv.State -ne "Enabled") {
        CbmrLogInfo "Hyper-V is not enabled on the host. Please enable with 'Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All'"
        return $False
    }

    if ([System.Environment]::OSVersion.Version.Build -lt 22538) {
        CbmrLogInfo "Hyper-V's UEFI do not have neccessary fixes for CBMR. Please make sure host's Windows build >= 22538"
        return $False
    }

    $tsharkExist = Test-Path "$env:SYSTEMDRIVE\Program Files\Wireshark\tshark.exe"
    if (-not $tsharkExist) {
        CbmrLogInfo "WireShark not found here $env:SYSTEMDRIVE\Program Files\Wireshark\. Install it from https://www.wireshark.org/download.html"
        return $False
    }

    $logpath = $config['logpath']
    if (!(Test-Path -Path $logpath)) {
        CbmrLogInfo "Do not have access to $logpath"
        return $False
    }

    # try {
    #     New-Object -ComObject Outlook.Application
    # } catch {
    #     CbmrLogInfo "Please install Outlook"
    #     return $False
    # }

    CbmrLogInfo "Installing CredentialManager prerequisite..."
    Install-Module -Name CredentialManager -Confirm:$False -Force

    return $True
}