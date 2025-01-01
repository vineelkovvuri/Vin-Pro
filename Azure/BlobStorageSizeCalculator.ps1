# Powershell script to calculate the container size(include all type of
# blobs(Base Blobs/Snapshots/Versions). This include soft deleted as well. This
# script directly uses the List Blob REST API
# https://learn.microsoft.com/en-us/rest/api/storageservices/list-blobs?tabs=azure-ad

# Sample postman URL to check the XML response
# https://st104062023.blob.core.windows.net/sample?sv=2021-12-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2023-04-12T14:07:00Z&st=2023-04-12T06:07:00Z&spr=https&sig=Xr5fyN4pl3%2BCMW4GfyzBrZcZChbFEC4TB4%2B2kRP%2B%2FUc%3D&include=snapshots,metadata,uncommittedblobs,copy,deleted,tags,versions,deletedwithversions,immutabilitypolicy,legalhold&restype=container&comp=list


# Inputs
$SasToken = "?<sastoken>"
$Container = "sample"
$StorageAccount = "st104062023"

# Code
$SnapshotsCount = 0;
$SnapshotsSize = 0;
$VersionsCount = 0;
$VersionsSize = 0;
$BaseBlobsCount = 0;
$BaseBlobsSize = 0;

$Include = "&include=snapshots,metadata,uncommittedblobs,copy,deleted,tags,versions,deletedwithversions,immutabilitypolicy,legalhold"
$ListAllBlobsUrl = "https://$($StorageAccount).blob.core.windows.net/$($Container)$($SasToken)$($Include)&restype=container&comp=list"
$ListAllBlobsUrlTemp = $ListAllBlobsUrl

while ($True) {
    $Response = [xml]((Invoke-RestMethod  $($ListAllBlobsUrlTemp)  -Method 'GET').SubString(3))
    $Blobs = $Response.EnumerationResults.Blobs.Blob

    # Filter blobs based on their type
    $Snapshots = $Blobs | Where-Object { $_.Snapshot -ne $null }
    $Versions = $Blobs | Where-Object { $_.VersionId -ne $null }
    $BaseBlobs = $Blobs | Where-Object { $_.Snapshot -eq $null -and $_.VersionId -eq $null }

    # Aggregate the count and their sizes
    $Snapshots | % { $SnapshotsCount++; $SnapshotsSize += $_.Properties.'Content-Length' }
    $Versions | % { $VersionsCount++; $VersionsSize += $_.Properties.'Content-Length' }
    $BaseBlobs | % { $BaseBlobsCount++; $BaseBlobsSize += $_.Properties.'Content-Length' }

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

"Snapshots  | Count: {0,-7} Size: {1,10} Bytes" -f $($SnapshotsCount), $($SnapshotsSize)
"Versions   | Count: {0,-7} Size: {1,10} Bytes" -f $($VersionsCount), $($VersionsSize)
"BaseBlobs  | Count: {0,-7} Size: {1,10} Bytes" -f $($BaseBlobsCount), $($BaseBlobsSize)
"---------------------------------------------------"
"Total Blob | Count: {0,-7} Size: {1,10} Bytes" -f $($SnapshotsCount + $VersionsCount + $BaseBlobsCount), $($SnapshotsSize + $VersionsSize + $BaseBlobsSize)

