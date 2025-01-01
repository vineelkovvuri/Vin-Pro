# The below script enumerates all the blobs in the storage account and prints
# the top 10 large files in each container.
# Please install powershell core (https://github.com/PowerShell/PowerShell/releases/download/v7.4.1/PowerShell-7.4.1-win-x64.msi) built in powershell do not work.
# open command prompt(not powershell prompt) and type pwsh.exe to launch powershell core prompt(this is not the same as launching powershell.exe)


# Update below three parameters accordingly.
#   1. SasToken create for the storage account
#   2. Storage account name
#   3. Container name
#   4. Prefix
$SasToken = "<sastoken>"
$StorageAccount = "folderstats"
$Containers = @("test")   # Include all the containers here as comma separated strings like @("c1", "c2", "c3")
$Prefix = "" # empty prefix will enumerate all files. If you want to enumerate files under a folder then please update this to the folder path like "folder1/folder2"
$TopX = 100; # Change this to print top X large files

############################## Code ##############################
$Prefix = $Prefix.Replace("\", "/").Trim("/");

if (!$SasToken.StartsWith("?")) {
    $SasToken = "?" + $SasToken;
}

class MinComparer : System.Collections.Generic.IComparer[System.Int64]
{
    [System.Int32] Compare([System.Int64] $x, [System.Int64] $y) {
        return $x.CompareTo($y);
    }
}

class MaxComparer : System.Collections.Generic.IComparer[System.Int64]
{
    [System.Int32] Compare([System.Int64] $x, [System.Int64] $y) {
        return $y.CompareTo($x);
    }
}

Function EnqueuePriorityQueue {
    param ($PriorityQueue, $Path, $Size)

    if ($PriorityQueue.Count -lt $TopX) {
        $PriorityQueue.Enqueue($Path, $Size) | Out-Null;
    } else {
        $PriorityQueue.EnqueueDequeue($Path, $Size) | Out-Null;
    }
}

Function PrettyPrintSize {
    param ($Size)

    if ($Size -gt 1GB) {
        return "{0:N2}{1, -7}" -f ($Size / 1GB), " GB";
    } elseif ($Size -gt 1MB) {
        return "{0:N2}{1, -7}" -f ($Size / 1MB), " MB";
    } elseif ($Size -gt 1KB) {
        return "{0:N2}{1, -7}" -f ($Size / 1KB), " KB";
    } else {
        return "{0:N2}{1, -7}" -f $Size, " Bytes";
    }
}

Function DumpPriorityQueue {
    param ($PriorityQueue, $Text)

    if ($PriorityQueue.Count -eq 0) {
        return;
    }

    $Path = "";
    $Size = 0;
    $MaxComparerObject = New-Object 'MaxComparer';
    $MaxPriorityQueue = New-Object 'System.Collections.Generic.PriorityQueue[System.String, System.Int64]' -ArgumentList $MaxComparerObject
    while ($PriorityQueue.TryDequeue([ref]$Path, [ref]$Size)) {
        EnqueuePriorityQueue -PriorityQueue $MaxPriorityQueue -Path $Path  -Size $Size | Out-Null;
    }

    Write-Host "Top $TopX $Text sorted by Size:"
    while ($MaxPriorityQueue.TryDequeue([ref]$Path, [ref]$Size)) {
        Write-Host ("Size: {0,15} Path: $Path" -f (PrettyPrintSize -Size $Size));
    }
}

# Write-Host "This script is expected to run for very long time depending up on the size of your contianers. It tries to print the blobs with snapshots as it enumerates each one of them"  -ForegroundColor White -BackgroundColor Red
$Containers | % {
    $MinComparerObject = New-Object 'MinComparer';
    $SnapShotPriorityQueue = New-Object 'System.Collections.Generic.PriorityQueue[System.String, System.Int64]' -ArgumentList $MinComparerObject
    $SnapShotPriorityQueue.EnsureCapacity($TopX) | Out-Null;
    $VersionsPriorityQueue = New-Object 'System.Collections.Generic.PriorityQueue[System.String, System.Int64]' -ArgumentList $MinComparerObject
    $VersionsPriorityQueue.EnsureCapacity($TopX) | Out-Null;
    $BaseBlobsPriorityQueue = New-Object 'System.Collections.Generic.PriorityQueue[System.String, System.Int64]' -ArgumentList $MinComparerObject
    $BaseBlobsPriorityQueue.EnsureCapacity($TopX) | Out-Null;

    $Container = $_;
    $SnapshotsCount = 0;
    $SnapshotsSize = 0;
    $VersionsCount = 0;
    $VersionsSize = 0;
    $BaseBlobsCount = 0;
    $BaseBlobsSize = 0;

    $Include = "&include=snapshots"#%82deleted%82versions%82deletedwithversions%82metadata%82tags%82immutabilitypolicy%82legalhold%82uncommittedblobs" # %82 means comma
    $ShowOnly = "&showonly=files" # showonly={deleted,files,directories} specify only one of these
    $PrefixParam = "&prefix=$($Prefix)"
    $ApiVersionParam = "&api-version=2021-02-12"
    $ListAllBlobsUrl = "https://$($StorageAccount).blob.core.windows.net/$($Container)$($SasToken)$($Include)$($ShowOnly)$($PrefixParam)$($ApiVersionParam)&restype=container&comp=list"
    $ListAllBlobsUrlTemp = $ListAllBlobsUrl

    Write-Host "Enumerating blobs/snapshots in Container($($Container)) with prefix($Prefix). Fetching next " -NoNewline

    while ($True) {
        $Response = [xml]((Invoke-RestMethod -Uri $ListAllBlobsUrlTemp -Method 'GET').SubString(1))
        $Blobs = $Response.EnumerationResults.Blobs.Blob

        Write-Host "$($Blobs.Count).." -NoNewline

        # $ListAllBlobsUrlTemp
        # Filter blobs based on their type
        # $Blobs = $Blobs | Where-Object { $_.Properties.ResourceType -eq "file" } # Only files
        $Snapshots = $Blobs | Where-Object { $_.Snapshot -ne $null }
        $Versions = $Blobs | Where-Object { $_.VersionId -ne $null }
        $BaseBlobs = $Blobs | Where-Object { $_.Snapshot -eq $null -and $_.VersionId -eq $null }

        # Aggregate the count and their sizes
        $Snapshots | % { $SnapshotsCount++; $Size = $_.Properties.'Content-Length'; $SnapshotsSize += $Size; EnqueuePriorityQueue -PriorityQueue $SnapShotPriorityQueue -Path "$($_.Name)" -Size $Size | Out-Null;}
        $Versions | % { $VersionsCount++; $Size = $_.Properties.'Content-Length'; $VersionsSize += $Size; EnqueuePriorityQueue -PriorityQueue $VersionsPriorityQueue -Path "$($_.Name)" -Size $Size | Out-Null;}
        $BaseBlobs | % { $BaseBlobsCount++; $Size = $_.Properties.'Content-Length'; $BaseBlobsSize += $Size; EnqueuePriorityQueue -PriorityQueue $BaseBlobsPriorityQueue -Path "$($_.Name)" -Size $Size | Out-Null;}

        # List Blob REST API at the max return on 5000 blobs per request and if
        # there are more blobs then a marker will be returned in the results as
        # 'NextMarker'. This 'NextMarker' should be used as marker URI parameter to
        # query the API again to get the next batch of blobs until. This should be
        # repeated until the NextMarker is empty
        if (-not [string]::IsNullOrEmpty($Response.EnumerationResults.NextMarker)) { # we have more results to iterate
            $ListAllBlobsUrlTemp = "$ListAllBlobsUrl&marker=$($Response.EnumerationResults.NextMarker)";
        } else {
            break;
        }
    }

    "   "
    "Folder($($Container)) statistics with prefix($Prefix):"
    "------------------------------------------------------------"
    "Snapshots  | Count: {0,-7} Size: {1,10}" -f $($SnapshotsCount), (PrettyPrintSize -Size $SnapshotsSize)
    "Versions   | Count: {0,-7} Size: {1,10}" -f $($VersionsCount), (PrettyPrintSize -Size $VersionsSize)
    "BaseBlobs  | Count: {0,-7} Size: {1,10}" -f $($BaseBlobsCount), (PrettyPrintSize -Size $BaseBlobsSize)
    "------------------------------------------------------------"
    "Total Blob | Count: {0,-7} Size: {1,10}" -f $($SnapshotsCount + $VersionsCount + $BaseBlobsCount), (PrettyPrintSize -Size $($SnapshotsSize + $VersionsSize + $BaseBlobsSize))
    "------------------------------------------------------------"

    DumpPriorityQueue -PriorityQueue $SnapShotPriorityQueue -Text "Snapshots"
    DumpPriorityQueue -PriorityQueue $VersionsPriorityQueue -Text "Versions"
    DumpPriorityQueue -PriorityQueue $BaseBlobsPriorityQueue -Text "Blobs"
    "============================================================"
}

