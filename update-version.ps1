#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Updates the version number in Directory.Build.props
.DESCRIPTION
    This script updates the version number in the Directory.Build.props file.
    It can be used to update the version before building the project.
.PARAMETER Version
    The version number to set (e.g., "0.1")
.PARAMETER BuildNumber
    The build number to set (e.g., "123"). Defaults to 0.
.PARAMETER VersionSuffix
    Optional version suffix (e.g., "beta", "alpha", "rc1")
.EXAMPLE
    ./update-version.ps1 -Version "0.1" -BuildNumber "123"
    ./update-version.ps1 -Version "0.1" -BuildNumber "123" -VersionSuffix "beta"
#>

param(
    [Parameter(Mandatory=$true)]
    [string]$Version,
    
    [Parameter(Mandatory=$false)]
    [string]$BuildNumber = "0",
    
    [Parameter(Mandatory=$false)]
    [string]$VersionSuffix = ""
)

# Validate version format (X.Y format)
if ($Version -notmatch '^\d+\.\d+$') {
    Write-Error "Invalid version format. Expected format: X.Y (e.g., 0.1)"
    exit 1
}

# Validate build number format
if ($BuildNumber -notmatch '^\d+$') {
    Write-Error "Invalid build number format. Expected a number (e.g., 123)"
    exit 1
}

$propsFile = Join-Path $PSScriptRoot "src/Directory.Build.props"

if (-not (Test-Path $propsFile)) {
    Write-Error "Directory.Build.props not found at: $propsFile"
    exit 1
}

Write-Host "Updating version to: $Version.$BuildNumber$(if ($VersionSuffix) { "-$VersionSuffix" })" -ForegroundColor Green

# Read the file
$content = Get-Content $propsFile -Raw

# Update VersionPrefix
$content = $content -replace '<VersionPrefix>.*?</VersionPrefix>', "<VersionPrefix>$Version</VersionPrefix>"

# Update BuildNumber - escape the pattern properly
$buildNumberReplacement = "<BuildNumber Condition=`"'`$(BuildNumber)' == ''`">$BuildNumber</BuildNumber>"
$content = $content -replace '<BuildNumber Condition="''[$][(]BuildNumber[)]'' == ''''">.*?</BuildNumber>', $buildNumberReplacement

# Update VersionSuffix
$content = $content -replace '<VersionSuffix>.*?</VersionSuffix>', "<VersionSuffix>$VersionSuffix</VersionSuffix>"

# Write back to file
Set-Content $propsFile $content -NoNewline

Write-Host "Version updated successfully!" -ForegroundColor Green
Write-Host "File: $propsFile" -ForegroundColor Cyan
