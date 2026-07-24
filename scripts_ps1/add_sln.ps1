param(
    [Parameter(Mandatory)]
    [string]$SolutionName,

    # [Parameter(Mandatory)]
    [int]$UpLevels = 0
)

$ErrorActionPreference = "Stop"

$target = Get-Location

for ($i = 0; $i -lt $UpLevels; $i++) {
    $target = Split-Path $target -Parent
}

$solutionPath = Join-Path $target $SolutionName

New-Item -ItemType Directory -Path $solutionPath
Set-Location $solutionPath

dotnet new sln -n $SolutionName