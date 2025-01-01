#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     Configuration.psm1
#
# Abstract:
#
#     This module implements parsing of CBMR E2E config xml(not cbmr config txt)
#
# Author:
#
#     Vineel Kovvuri (vineelko) 27-Feb-2022
#
# Environment:
#
#     User mode only.
#

Function CbmrScriptRoot {
    $scriptRoot = ""

    try {
        $scriptRoot = Get-Variable -Name PSScriptRoot -ValueOnly
    }
    catch {
        $scriptRoot = Split-Path $script:MyInvocation.MyCommand.Path
    }

    return $scriptRoot
}

$global:config = $null
$global:configFilePath = $null

Function CbmrSetConfigFile {
    param($ConfigFile)

    $global:config = $null
    $global:configFilePath = $ConfigFile
}

Function CbmrReadConfig {

    if (!$global:config) {
        $scriptRoot = CbmrScriptRoot

        [xml]$config = Get-Content $global:configFilePath

        $enabled = $config.SelectSingleNode("/cbmr/enabled").InnerText

        $build = $config.SelectSingleNode("/cbmr/build").InnerText
        $branch = $config.SelectSingleNode("/cbmr/branch").InnerText
        $endpointtype = $config.SelectSingleNode("/cbmr/endpointtype").InnerText
        $ppeendpoint = $config.SelectSingleNode("/cbmr/ppeendpoint").InnerText
        $prodendpoint = $config.SelectSingleNode("/cbmr/prodendpoint").InnerText
        $cbmrconfigfilepath = "$([System.IO.Path]::GetDirectoryName($global:configFilePath))\$([System.IO.Path]::GetFileNameWithoutExtension($global:configFilePath))_cbmr_config.txt"
        $vmconfigpath = $config.SelectSingleNode("/cbmr/vmconfigpath").InnerText
        $memory = $config.SelectSingleNode("/cbmr/memory").InnerText
        $cores = $config.SelectSingleNode("/cbmr/cores").InnerText

        $emailto = $config.SelectSingleNode("/cbmr/emailto").InnerText
        $logpath = $config.SelectSingleNode("/cbmr/logpath").InnerText

        if ($vmconfigpath -eq ".") {
            $vmconfigpath = "$scriptRoot\vmconfig"
        }

        $memory = $memory / 1

        $global:config = [ordered]@{
            "enabled"             = $enabled

            "build"               = $build
            "branch"              = $branch
            "cbmrconfigfilepath"  = $cbmrconfigfilepath
            "endpointtype"        = $endpointtype
            "ppeendpoint"         = $ppeendpoint
            "prodendpoint"        = $prodendpoint

            "vmconfigpath"        = $vmconfigpath
            "memory"              = $memory
            "cores"               = $cores

            "emailto"             = $emailto
            "logpath"             = $logpath
        }
    }

    return $global:config;
}
