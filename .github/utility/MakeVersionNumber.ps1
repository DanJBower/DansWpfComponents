param([string] $append, [int] $buildId, [string] $latest)

Write-Host "Append: $($append)"
Write-Host "Build ID: $($buildId)"
Write-Host "Latest Release: $($latest)"

$pipelinePackageVersion = "$($latest)$($append)"

# Max segment is 65000 so get the modulus of buildId
$build = $buildId % 65000

$splitVersion = $latest.Split(".")
$major = $splitVersion[0]
$minor = $splitVersion[1]
$patch = $splitVersion[2].Split("-")[0]

$pipelineAssemblyVersion = "$($major).$($minor).$($patch).$($build)"

Write-Host "::set-output name=pipelinePackageVersion::$($pipelinePackageVersion)"
Write-Host "::set-output name=pipelineAssemblyVersion::$($pipelineAssemblyVersion)"
Write-Host "Package Version: $($pipelinePackageVersion)"
Write-Host "Assembly Version: $($pipelineAssemblyVersion)"
