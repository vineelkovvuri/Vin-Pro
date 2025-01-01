# Run powershell .\pr_list.ps1
# This file should be saved as UTF-8 with BOM

# List of repositories to fetch PRs from
$repos = @(
    "pop-project/mtrr",
    "pop-project/paging",
    "pop-project/uefi-dxe-core",
    "pop-project/uefi-core",
    "pop-project/uefi-sdk"
)

# Loop that runs continuously
while ($true) {

    # Array to store all PR data
    $allPrResults = @()

    # Loop through each repository and fetch PR data
    foreach ($repo in $repos) {

        # Fetch PR data for the current repo
        $prList = gh pr list --repo $repo --json "author,title,url,updatedAt,mergeStateStatus,mergeable,reviews" | ConvertFrom-Json

        # Process and add each PR to the results array
        $prList | ForEach-Object {
            # Map mergeStateStatus to a descriptive message
            $mergeStateDescription = switch ($_.mergeStateStatus) {
                "BEHIND" { "🦕 Stale out of date" }
                "BLOCKED" { "🕵️ Pending review" }
                "CLEAN" { "✅ Mergeable and passing commit status" }
                "DIRTY" { "⚔️ Merge conflict" }
                "DRAFT" { "📝 Draft PR" }
                "HAS_HOOKS" { "Mergeable with passing commit status and pre-receive hooks" }
                "UNKNOWN" { "The state cannot currently be determined" }
                "UNSTABLE" { "Mergeable with non-passing commit status" }
                default { "❓ Unknown state. $($_.mergeStateStatus)" }
            }

            # Extract your review status (vineelko)
            $yourReviewStatus = ($_.reviews | Where-Object { $_.author.login -eq "vineelko" }).state
            $reviewers = if ($yourReviewStatus) {
                "vineelko: $yourReviewStatus"
            } else {
                "None"
            }

            $allPrResults += [PSCustomObject]@{
                "Repository" = $repo
                "Updated At" = (Get-Date $_.updatedAt -Format "yyyy-MM-dd: hh:mm:ss tt")
                "Author"     = if ($_.author.name) { $_.author.name } else { $_.author.login }
                "Title"      = $_.title
                "URL"        = $_.url
                "Mergeable"  = "$mergeStateDescription($($_.mergeable))"
                "Reviewers"  = $reviewers
            }
        }
    }

    # Sort by "Updated At" and group by "Repository"
    $sortedGroupedResults = $allPrResults | Sort-Object -Property "Updated At" -Descending | Group-Object -Property "Repository"

    # Clear the screen
    Clear-Host

    # Print all collected, sorted, and grouped PR results at the end
    foreach ($group in $sortedGroupedResults) {
        $prCount = $group.Group.Count
        Write-Host "`nRepository: $($group.Name) - PR Count: $prCount"
        $group.Group | Select-Object "Updated At", "Author", "Title", "URL", "Mergeable", "Reviewers" | Format-Table -AutoSize
    }

    # Wait for 1 minute before refreshing the output
    Start-Sleep -Seconds (60 * 5)
}
