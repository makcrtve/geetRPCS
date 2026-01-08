# Installer for geetRPCS
param(
    [Parameter(Mandatory=$false)]
    [ValidateSet("minimal", "portable")]
    [string]$Version = "portable"
)

Write-Host "Downloading geetRPCS..." -ForegroundColor Green

if ($Version -eq "minimal") {
    $downloadUrl = "https://github.com/makcrtve/geetRPCS/releases/download/v1.2.6/geetRPCS-v1.2.6-minimal.zip"
    $fileName = "geetRPCS-v1.2.6-minimal.zip"
} else {
    $downloadUrl = "https://github.com/makcrtve/geetRPCS/releases/download/v1.2.6/geetRPCS-v1.2.6-portable.zip"
    $fileName = "geetRPCS-v1.2.6-portable.zip"
}

$tempPath = "$env:TEMP\$fileName"
$installDir = "$env:LOCALAPPDATA\geetRPCS"

try {
    if (-not (Test-Path $installDir)) {
        New-Item -ItemType Directory -Path $installDir -Force | Out-Null
    }

    Write-Host "Downloading $Version version..." -ForegroundColor Yellow
    irm -Uri $downloadUrl -OutFile $tempPath -ErrorAction Stop

    Write-Host "Extracting files..." -ForegroundColor Yellow
    Expand-Archive -Path $tempPath -DestinationPath $installDir -Force -ErrorAction Stop

    Remove-Item $tempPath -Force

    Write-Host "Installation completed successfully!" -ForegroundColor Green
    Write-Host "Files installed to: $installDir" -ForegroundColor Cyan
    Write-Host "You can now run geetRPCS from the installed directory." -ForegroundColor Cyan
    
} catch {
    Write-Error "Installation failed: $($_.Exception.Message)"
}
