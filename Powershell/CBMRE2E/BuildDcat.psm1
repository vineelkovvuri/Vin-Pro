#
# Copyright (c) 2022  Microsoft Corporation
#
# Module Name:
#
#     BuildDcat.psm1
#
# Abstract:
#
#     This module implements logic to identify the dcat published build
#
# Author:
#
#     Vineel Kovvuri (vineelko) 01-Mar-2022
#
# Environment:
#
#     User mode only.
#

Import-Module .\Logging.psm1
Import-Module .\Configuration.psm1
Import-Module .\Utilities.psm1

Function CbmrGetDCATPublishedBuild
{
    $branch = $config["branch"]

    $endpointtype = $config["endpointtype"]
    $ppeendpoint = $config["ppeendpoint"]
    $prodendpoint = $config["prodendpoint"]

    # Control Tower does provide an API to get the latest published build. But
    # unfortunately we don't have the time to explore and use that API. So lets
    # simply query DCAT with the latest builds from winbuilds and see what comes
    # out! Below logic tries to pick the last 50 builds from the winbuilds and
    # tries to find if that build is published to DCAT

    $builds = Get-ChildItem "\\winbuilds\release\$branch\" | `
                Sort-Object -Property CreationTime -Descending | `
                Where-Object {Test-Path "$($_.FullName)\amd64fre\vhdx\vhdx_client_enterprise_en-us_vl"} | `
                Select-Object -First 50

    $i = 0
    for ($i = 0; $i -lt $builds.Count; $i++) {

        $buildVersion = ($builds[$i].Name -split '\.')[0]
        $buildBaseline = ($builds[$i].Name -split '\.')[1]


        #Write-Host "$buildVersion.$buildBaseline"

        if ($endpointtype -eq "ppe") {
            $uri = $ppeendpoint
            $params = @{
                "Products" = "PN=Client.OS.RS2.amd64&V=10.0.$buildVersion.$buildBaseline"
                # "DeviceAttributes" = "MediaVersion=10.0.$buildVersion.$buildBaseline;MediaBranch=$branch;OSSkuId=4;App=Setup360;AppVer=10.0;DUScan=1;DUInternal=1"
                "DeviceAttributes" = "MediaVersion=10.0.$buildVersion.$buildBaseline;MediaBranch=$branch;OSSkuId=4;App=Setup360;AppVer=10.0;CBMRScan=1;DUInternal=1"
                # Skuid=4 means enterprise. Documented below
                # https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getproductinfo
            }
        } elseif ($endpointtype -eq "prod") {
            $uri = $prodendpoint
            $params = @{
                "Products" = "PN=Client.OS.RS2.amd64&V=10.0.$buildVersion.$buildBaseline"
                "DeviceAttributes" = "MediaVersion=10.0.$buildVersion.$buildBaseline;MediaBranch=$branch;OSSkuId=4;App=Setup360;AppVer=10.0;CBMRScan=1;"
            }
        }

        $json = $params | ConvertTo-JSON

        $cv =  "abcdefghi12451" # (New-Object -TypeName Microsoft.CommonSchema.Services.Logging.CorrelationVector).ToString()
        $headers = @{
            'MS-CV' = $cv
        }

        $result = Invoke-RestMethod -Uri $uri -TimeoutSec 60 -Method Post -Body $json -ContentType "application/json" -Headers $headers

        if ($result) {
            if ($result.FileLocations | ? { $_.FileName.Contains("winre.wim")}) {
                break;
            }
         }
    }

    if ($i -ge $builds.Count) {
        throw "Unable to find the build published to DCAT"
    } else {
        return $builds[$i].Name;
    }
}

Function CbmrGetBuildDirectory
{
    $config = CbmrReadConfig

    $branch = $config["branch"]
    $build = $config["build"]

    # If a specific build is not specified then get the published build from DCAT
    if (!$build) {
        $config["build"] = CbmrGetDCATPublishedBuild
        $build = $config["build"]
    }

    CbmrLogInfo "Found build $build"

    return "\\winbuilds\release\$branch\$build\";
}

