#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     Utilities.psm1
#
# Abstract:
#
#     This module implements common utility routines
#
# Author:
#
#     Vineel Kovvuri (vineelko) 21-Feb-2022
#
# Environment:
#
#     User mode only.
#

Function CbmrEnsurePathExist {
    param($Path)
    $exist = Test-Path -Path $Path
    if (-not $exist) {
        if ([System.IO.Path]::HasExtension($Path)) {
            New-Item -ItemType File $Path -Force | Out-Null
        } else {
            New-Item -ItemType Directory $Path -Force | Out-Null
        }
    }
}

Function CbmrEnsureDirectoryExistAndEmpty {
    param($Path)

    New-Item -ItemType Directory $Path -Force | Out-Null

    Remove-Item -Path "$Path\*.*" -Force  | Out-Null
}

Function CbmrGetFileNameWithoutExtension {
    param($Path)
    return [System.IO.Path]::GetFileNameWithoutExtension($Path)
}

Function CbmrGetFileName {
    param($Path)
    return Split-Path $Path -Leaf
}

Function CbmrGetParentDirectory {
    param($Path)
    return Split-Path $Path -Parent
}

Function CbmrCopyFile {
    param($SourceFile, $DestinationDirectory)

    # Bits can shows progress. Copy-Item do not!
    New-Item $DestinationDirectory -ItemType Directory -ErrorAction SilentlyContinue | Out-Null
    Start-BitsTransfer -Source  $SourceFile -Destination  $DestinationDirectory -TransferType Download | Out-Null
}

Function CbmrCopyDirectory {
    param($SourceDirectory, $DestinationDirectory)

    # Bits can shows progress. Copy-Item do not!

    $directories = Get-ChildItem -Name -Path $SourceDirectory -Directory -Recurse
    Start-BitsTransfer -Source $SourceDirectory\*.* -Destination $DestinationDirectory
    $directories | ForEach-Object {
        New-Item $DestinationDirectory\$_ -ItemType Directory  -ErrorAction SilentlyContinue | Out-Null
        Start-BitsTransfer -Source $SourceDirectory\$_\*.* -Destination $DestinationDirectory\$_
    }
}
