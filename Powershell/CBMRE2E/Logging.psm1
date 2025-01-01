#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     Logging.psm1
#
# Abstract:
#
#     This module implements common logging routines
#
# Author:
#
#     Vineel Kovvuri (vineelko) 21-Feb-2022
#
# Environment:
#
#     User mode only.
#

$CbmrDateFormat = "MM-dd-yyyy hh:mm:ss tt"

#
# Logging methods
#

Function CbmrLog {
    param($Message, [switch]$Warning)

    $date = "$((Get-Date).ToString($CbmrDateFormat))"

    if ($Warning) { Write-Warning "$date : $Message" }
    else { Write-Host "$date : $Message" }
}

Function CbmrLogWarning {
    param($Message)

    CbmrLog -Message $Message -Warning
}

Function CbmrLogInfo {
    param($Message)

    CbmrLog -Message $Message
}
