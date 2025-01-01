#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     VMScreenCapture.psm1
#
# Abstract:
#
#     This module implements routines to capture the VM screen
#
# Author:
#
#     Vineel Kovvuri (vineelko) 21-Feb-2022
#
# Environment:
#
#     User mode only.
#

Add-Type -AssemblyName "System.Drawing"

Function CbmrCaptureVMScreen {
    param($VMName)

    $vmms = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_VirtualSystemManagementService
    $vmcs = Get-WmiObject -Namespace root\virtualization\v2 -Class Msvm_ComputerSystem -Filter "ElementName='$($VMName)'"

    # Wakeup the VM
    $mouse = $vmcs.GetRelated("Msvm_SyntheticMouse")
    $mouse.SetAbsolutePosition(300,450) | out-null
    # $mouse.ClickButton(2) | out-null

    # Get the resolution of the screen at the moment
    $video = $vmcs.GetRelated("Msvm_VideoHead")
    $xRes = $video.CurrentHorizontalResolution[0]
    $yRes = $video.CurrentVerticalResolution[0]

    # Get screenshot
    $image = $vmms.GetVirtualSystemThumbnailImage($vmcs, $xRes, $yRes).ImageData

    # Transform into bitmap
    $bitMap = New-Object System.Drawing.Bitmap -Args $xRes, $yRes, Format16bppRgb565
    $rect = New-Object System.Drawing.Rectangle 0, 0, $xRes, $yRes
    $bmpData = $bitMap.LockBits($rect, "ReadWrite", "Format16bppRgb565")

    [System.Runtime.InteropServices.Marshal]::Copy($image, 0, $bmpData.Scan0, $bmpData.Stride * $bmpData.Height)
    $bitMap.UnlockBits($bmpData)

    # Convert from 16bppRgb565 to 24bppRgb
    $capturedImage = New-Object System.Drawing.Bitmap -Args $bitMap.Width, $bitMap.Height, Format24bppRgb
    $graphics = [System.Drawing.Graphics]::FromImage($capturedImage)
    $graphics.DrawImage($bitMap, (New-Object System.Drawing.Rectangle(0, 0, $bitMap.Width, $bitMap.Height)))

    return $capturedImage
}

Function CbmrCompareBitMapSignature {
    param($BitMap, $Signature)

    foreach ($pixeldata in $Signature) {
        $x, $y, $color = $pixeldata
        if ($Bitmap.GetPixel($x, $y).Name -ne $color) {
            return $False;
        }
    }

    return $True;
}

Function CbmrGetBitMap {
    param($BitMapFile)

    $image = New-Object System.Drawing.Bitmap($BitMapFile);

    $capturedImage = New-Object System.Drawing.Bitmap -Args $image.Width, $image.Height, Format24bppRgb
    $graphics = [System.Drawing.Graphics]::FromImage($capturedImage)
    $graphics.DrawImage($image, (New-Object System.Drawing.Rectangle(0, 0, $image.Width, $image.Height)))
    $image.Dispose()
    return $capturedImage
}

Function CbmrExactImageCompare {
    param($BitMap1, $BitMap2)

    $rect1 = New-Object System.Drawing.Rectangle 0, 0, $BitMap1.Width, $BitMap1.Height
    $bmpData1 = $BitMap1.LockBits($rect1, "ReadWrite", "Format24bppRgb")
    $length1 = $bmpData1.Stride * $bmpData1.Height
    $rawdata1 = new-object byte[] $length1
    [System.Runtime.InteropServices.Marshal]::Copy($bmpData1.Scan0, $rawdata1, 0, $length1)
    $BitMap1.UnlockBits($bmpData1)

    $rect2 = New-Object System.Drawing.Rectangle 0, 0, $BitMap2.Width, $BitMap2.Height
    $bmpData2 = $BitMap2.LockBits($rect2, "ReadWrite", "Format24bppRgb")
    $length2 = $bmpData2.Stride * $bmpData2.Height
    $rawdata2 = new-object byte[] $length2
    [System.Runtime.InteropServices.Marshal]::Copy($bmpData2.Scan0, $rawdata2, 0, $length1)
    $BitMap2.UnlockBits($bmpData2)

    return [Linq.Enumerable]::SequenceEqual($rawdata1, $rawdata2)
}