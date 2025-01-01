

$OrgsMap = @(
    [PSCustomObject]@{ Organization = "microsoft"; Project = "MsUEFI"; PAT = "<PAT>" } # https://dev.azure.com/microsoft/MsUEFI
    # [PSCustomObject]@{ Organization = "projectmu"; Project = "mu"; PAT = "<PAT>" } # https://dev.azure.com/projectmu/mu
);

foreach ($org in $OrgsMap) {
    $organization = $($org.Organization);
    $project = $($org.Project);
    $pat = $($org.PAT);

    # curl -s -u vineelko:<PAT>  https://dev.azure.com/microsoft/MsUEFI/_apis/pipelines?api-version=6.0 | jq ".value[] | {name: .name, url: .url, url2: ._links.web.href}"
    # curl -s -u vineelko:<PAT>  https://dev.azure.com/microsoft/2321e82f-40f9-420d-a7da-11a3bda470a3/_apis/pipelines/94328?revision=8 | jq " select(.configuration.type==\"yaml\") | {id: .configuration.repository.id, name: .name, folder: .folder, path: .configuration.path, def: ._links.web.href}"

    # Get id <-> repo hash map
    $repoHashTable = @{}
    $uri = "https://dev.azure.com/$organization/$project/_apis/git/repositories?api-version=6.0"
    $headers = @{
        Authorization = "Basic " + [Convert]::ToBase64String([Text.Encoding]::ASCII.GetBytes(":$pat"))
    }
    $response = Invoke-RestMethod -Uri $uri -Method Get -Headers $headers
    $response.value | % { $repoHashTable[$_.id] = $_.name }
    # $repoHashTable

    $pipelineDetails = @()
    $pipelineUrls = @()
    # Get pipelines
    $uri = "https://dev.azure.com/$organization/$project/_apis/pipelines?api-version=6.0"
    $response = Invoke-RestMethod -Uri $uri -Method Get -Headers $headers
    $response.value | % { $pipelineUrls += $_.url }

    $pipelineUrls | % {
        $pipelineUrl = $_;
        $response = Invoke-RestMethod -Uri $pipelineUrl -Method Get -Headers $headers
        $response | ? { $_.configuration.type -eq "yaml" } | % {
            $pipelineDetails += [PSCustomObject]@{
                Name       = $_.name
                Folder     = $_.folder
                Repository = $repoHashTable[$_.configuration.repository.id]
                YamlPath   = $_.configuration.path
            }
        }
    }

    $sortedPipelineDetails = $pipelineDetails | Sort-Object -Property Repository, Folder

    Write-Output "Dumping Org: $organization Project: $project pipeline and repo branch polices..."
    Write-Output "-------------------------------------PROJECT PIPELINES AND THEIR AUTHORED REPOS----------------------------------------------"
    # Output the sorted pipeline details
    "{0, -40} | {1, -10} | {2, -10} | {3, -40}" -f "Pipeline Name", "Folder", "Repo", "Yaml Path"
    "{0, -40} | {1, -10} | {2, -10} | {3, -40}" -f ("-" * 40), ("-" * 10), ("-" * 10), ("-" * 40)
    $sortedPipelineDetails | ForEach-Object {
        "{0, -40} | {1, -10} | {2, -10} | {3, -40}" -f $_.Name, $_.Folder, $_.Repository, $_.YamlPath
    }

    Write-Output ""
    Write-Output ""
    Write-Output "-------------------------------------REPOS AND THEIR MAIN BRANCH POLICY GATES----------------------------------------------"
    "{0, -10} | {1, -20} | {2, -40} | {3, -40}" -f "Repo", "Branch", "Policy Display Name", "Pipeline Name"
    "{0, -10} | {1, -20} | {2, -40} | {3, -40}" -f ("-" * 10), ("-" * 20), ("-" * 40), ("-" * 40)

    $repoHashTable.GetEnumerator() | ForEach-Object {
        # if ($_.Value -eq "DxeRust") {
        # Write-Output "Id: $($_.Key), Name: $($_.Value)"
        $repoName = $_.Value;
        $repositoryId = $_.Key;

        $uri = "https://dev.azure.com/$organization/$project/_apis/policy/configurations?repositoryId=$repositoryId&api-version=6.0"

        $response = Invoke-RestMethod -Uri $uri -Method Get -Headers $headers
        $response.value | ForEach-Object {

            $branch = $_.settings.scope[0].refName;
            $type = $_.type.displayName;
            if ($_.isEnabled -and $branch -eq "refs/heads/main" -and $type -eq "Build" `
                    -and $_.settings.scope.repositoryId -eq $repositoryId) {
                # Write-Output "Policy ID: $($_.id)"
                # Write-Output "Type: $($type)"
                # Write-Output "Url: $($_.url)"

                $buildDefinitionId = $_.settings.buildDefinitionId;
                # write-output "buildDefinitionId : $buildDefinitionId"
                $buildDefinitionIdUri = "https://dev.azure.com/$organization/$project/_apis/build/definitions/$($buildDefinitionId)?api-version=6.0"
                # write-output $buildDefinitionIdUri
                $buildDefinitionResponse = Invoke-RestMethod -Uri $buildDefinitionIdUri -Method Get -Headers $headers
                if ($buildDefinitionResponse -ne $null) {
                    $pipelineName = $buildDefinitionResponse.name
                    $displayName = if ($_.settings.displayName -eq $null) { $pipelineName } else { $_.settings.displayName };
                    # Write-Output "Repo: $($repoName) | Branch: $($branch) | Policy Display Name: $($_.settings.displayName) | Pipeline Name: $pipelineName"
                    "{0, -10} | {1, -20} | {2, -40} | {3, -40}" -f $repoName, $branch, $displayName, $pipelineName
                }
            }
        }
        # }
    }
}
