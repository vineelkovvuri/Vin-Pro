$files = git ls-files
$filesList = foreach ($file in $files) {
    $date = git log -1 --format="%ai" -- $file
    if ($date) {
        [PSCustomObject]@{
            LastCommitDate = $date
            FileName       = $file
        }
    }
}

$filesList = $filesList | Sort-Object LastCommitDate, FileName
$filesList
# $filesList | % {
#     if ($_.FileName -ne "main.rs" -and -not $_.FileName.StartsWith("2024")) {
#         # Rename-Item "$($_.FileName)" "$((Get-Date $date).ToString("yyyyMMdd_HHmmss"))_$($_.FileName)"
#         Rename-Item "$($_.FileName)" "$((Get-Date $_.LastCommitDate).ToString("yyyyMMdd_HHmmss"))_$($_.FileName)"
#         # Write-Host "$($_.FileName)" "$((Get-Date $_.LastCommitDate).ToString("yyyyMMdd_HHmmss"))_$($_.FileName)"
#     }
# }

