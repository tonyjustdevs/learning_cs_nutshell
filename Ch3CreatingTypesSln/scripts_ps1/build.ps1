param(
    [Parameter(Mandatory)]
    [string]$ConsoleName,

    [int]$UpLevels = 1
)

$ErrorActionPreference = "Stop"

$target = Get-Location
$oglocation = $target

try {

    for ($i = 0; $i -lt $UpLevels; $i++) {
        $target = Split-Path $target -Parent
    }

    Set-Location $target    # Go to the solution directory
    $projectPath = ".\$ConsoleName\src\$ConsoleName.csproj"
    
    dotnet restore $projectPath
    if ($LASTEXITCODE -ne 0) { throw "dotnet restore failed with exit code $LASTEXITCODE" }
    
    dotnet build --no-restore $projectPath --configuration Release 
    if ($LASTEXITCODE -ne 0) { throw "dotnet build failed with exit code $LASTEXITCODE" }
    
    dotnet run --project $projectPath --no-build --configuration Release
    if ($LASTEXITCODE -ne 0) { throw "dotnet run failed with exit code $LASTEXITCODE" }
}
finally {
    Set-Location $oglocation
}