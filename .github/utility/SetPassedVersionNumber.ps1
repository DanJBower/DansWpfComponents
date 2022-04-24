param([string] $latest)

Write-Host "Latest Release: $($latest)"

$pipelinePackageVersion = "$($latest)"

$splitVersion = $latest.Split(".")
$major = $splitVersion[0]
$minor = $splitVersion[1]
$patch = $splitVersion[2].Split("-")[0]

$pipelineAssemblyVersion = "$($major).$($minor).$($patch).0"

Write-Host "::set-output name=pipelinePackageVersion::$($pipelinePackageVersion)"
Write-Host "::set-output name=pipelineAssemblyVersion::$($pipelineAssemblyVersion)"
Write-Host "Package Version: $($pipelinePackageVersion)"
Write-Host "Assembly Version: $($pipelineAssemblyVersion)"
