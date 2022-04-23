param([string] $append, [int] $buildId)

Write-Host "Append: $($append)"
Write-Host "Build ID: $($buildId)"

Push-Location

Set-Location "$($PSScriptRoot)"
Set-Location ..

$tags = git tag --merged "origin/main"

$logs = @()

foreach ($tag in $tags) {
    $logs += git log --format=format:"%ai $($tag)%n" -1 $tag
}

$logs = $logs | Sort-Object -Descending

foreach ($log in $logs) {
    Write-Host $log
    $log = $log.Split(" ")[3]

    if ("$($log)" -match '^(0|[1-9]\d*)\.(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+([0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$') {
        $latest = $log
        break
    }
}

if ($null -eq $latest) {
    Write-Error "No valid tags found"
}

$pipelinePackageVersion = "$($latest)$($append)"

# Max segment is 65000 so get the modulus of buildId
$build = $buildId % 65000

$splitVersion = $latest.Split(".")
$major = $splitVersion[0]
$minor = $splitVersion[1]
$patch = $splitVersion[2].Split("-")[0]

$pipelineAssemblyVersion = "$($major).$($minor).$($patch).$($build)"

Write-Host "##vso[task.setvariable variable=pipelinePackageVersion]$($pipelinePackageVersion)"
Write-Host "##vso[task.setvariable variable=pipelineAssemblyVersion]$($pipelineAssemblyVersion)"
Write-Host "Package Version: $($pipelinePackageVersion)"
Write-Host "Assembly Version: $($pipelineAssemblyVersion)"

Pop-Location
