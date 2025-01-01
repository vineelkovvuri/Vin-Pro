#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     VhdUtilities.psm1
#
# Abstract:
#
#     This module implements common VHD related utility routines
#
# Author:
#
#     Vineel Kovvuri (vineelko) 23-Feb-2022
#
# Environment:
#
#     User mode only.
#

Function CbmrMountVhd {
    param($VhdPath)
    Mount-VHD -Path $VhdPath  | Out-Null
}

Function CbmrDismountVhd {
    param($VhdPath)
    Dismount-Vhd -Path $VhdPath  | Out-Null
}

Function CbmrFormatVhd {
    param($VhdPath)
    $disk = Get-Vhd -path $VhdPath
    Initialize-Disk $disk.DiskNumber
    $partition = New-Partition -AssignDriveLetter -UseMaximumSize -DiskNumber $disk.DiskNumber
    $volume = Format-Volume -FileSystem FAT32 -Confirm:$False -Force -Partition $partition
    return $volume.DriveLetter
}

Function CbmrGetMountedVhdDriveLetter {
    param($VhdPath)

    $partition = Get-Vhd $VhdPath | Get-Disk | Get-Partition |  ? { $_.Type -eq "Basic"}
    $driveLetter = $partition.DriveLetter

    if (!$driveLetter) {
        $partition | Set-Partition -NewDriveLetter Z
        $partition = Get-Vhd $VhdPath | Get-Disk | Get-Partition |  ? { $_.Type -eq "Basic"}
        $driveLetter = $partition.DriveLetter
    }

    return $driveLetter
}

Function CbmrResizeAndClearOsVhd {
    param($VM)

    # Resize the disk to say 400 GB as Winbuilds vhds are only 70GB
    $VM | Select-Object VMid | Get-VHD | Where-Object {!$_.Path.Contains("uefishell")} | Resize-VHD -SizeBytes 400GB

    # Uninitialize the disk - This is needed because StubOS disk selection logic
    # might fail to detect candidate disk
    $Vhd = $VM | Select-Object VMid | Get-VHD | Where-Object {!$_.Path.Contains("uefishell")}
    CbmrMountVhd -VhdPath $($Vhd.Path)
    $Vhd = $VM | Select-Object VMid | Get-VHD | Where-Object {!$_.Path.Contains("uefishell")}
    # Clear-Disk -Number $($Vhd.Number) -RemoveData -RemoveOEM -Confirm:$false -ErrorAction SilentlyContinue | Out-Null
    CbmrDismountVhd -VhdPath $($Vhd.Path)
}