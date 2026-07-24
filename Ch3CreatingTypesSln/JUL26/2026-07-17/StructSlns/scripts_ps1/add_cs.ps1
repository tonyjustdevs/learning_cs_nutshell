param(
    [Parameter(Mandatory)]
    [string]$ConsoleName,

    [int]$UpLevels = 1
)

$ErrorActionPreference = "Stop"

$target = Get-Location

for ($i = 0; $i -lt $UpLevels; $i++) {
    $target = Split-Path $target -Parent
}

# Go to the solution directory
Set-Location $target

# Create the project
dotnet new console `
    -n $ConsoleName `
    -o ".\$ConsoleName\src" `
    -f net8.0 `
    --use-program-main

# Add it to whichever solution is in this directory
dotnet sln add ".\$ConsoleName\src\$ConsoleName.csproj"