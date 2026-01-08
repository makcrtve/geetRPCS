function Install-GeetRPCS {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [ValidateSet("minimal", "portable")]
        [string]$Version = "portable",

        [Parameter(Mandatory=$false)]
        [switch]$DesktopShortcut
    )

    $repo = "makcrtve/geetRPCS"
    $installDir = "$env:LOCALAPPDATA\geetRPCS"
    $exeName = "geetRPCS.exe"

    Write-Host "`n==========================================" -ForegroundColor Cyan
    Write-Host "       geetRPCS Installer" -ForegroundColor Cyan
    Write-Host "==========================================`n" -ForegroundColor Cyan

    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    try {
        Write-Host "[1/5] Checking latest version from GitHub..." -ForegroundColor Yellow
        $releaseInfo = Invoke-RestMethod -Uri "https://api.github.com/repos/$repo/releases/latest" -ErrorAction Stop
        $tag = $releaseInfo.tag_name
        
        $asset = $releaseInfo.assets | Where-Object { $_.name -like "*$Version.zip" } | Select-Object -First 1
        if (-not $asset) { throw "Could not find the $Version version for release $tag" }

        $downloadUrl = $asset.browser_download_url
        $tempPath = Join-Path $env:TEMP $asset.name

        $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
        if ($process) {
            Write-Host "[!] geetRPCS is currently running. Closing it to update..." -ForegroundColor Yellow
            Stop-Process -Name "geetRPCS" -Force
            Start-Sleep -Seconds 1
        }

        if (-not (Test-Path $installDir)) { 
            New-Item -ItemType Directory -Path $installDir -Force | Out-Null 
        }
        
        Write-Host "[2/5] Downloading $Version version ($tag)..." -ForegroundColor Green
        Invoke-WebRequest -Uri $downloadUrl -OutFile $tempPath -UseBasicParsing

        Write-Host "[3/5] Extracting files to LocalAppData..." -ForegroundColor Yellow
        Expand-Archive -Path $tempPath -DestinationPath $installDir -Force
        Remove-Item $tempPath -Force

        if ($DesktopShortcut) {
            Write-Host "[4/5] Creating Desktop shortcut..." -ForegroundColor Yellow
            $desktopPath = [Environment]::GetFolderPath("Desktop")
            $shortcutPath = Join-Path $desktopPath "geetRPCS.lnk"
            $targetPath = Join-Path $installDir $exeName
            
            $WshShell = New-Object -ComObject WScript.Shell
            $Shortcut = $WshShell.CreateShortcut($shortcutPath)
            $Shortcut.TargetPath = $targetPath
            $Shortcut.WorkingDirectory = $installDir
            $Shortcut.IconLocation = "$targetPath,0"
            $Shortcut.Save()
        } else {
            Write-Host "[4/5] Skipping shortcut creation (use -DesktopShortcut to enable)." -ForegroundColor Gray
        }

        Write-Host "[5/5] Finalizing installation..." -ForegroundColor Yellow
        Start-Sleep -Seconds 1

        Write-Host "`n✅ Installation completed successfully!" -ForegroundColor Green
        Write-Host "--------------------------------------------------" -ForegroundColor Cyan
        Write-Host "LOCATION: $installDir" -ForegroundColor White
        Write-Host "--------------------------------------------------" -ForegroundColor Cyan
        Write-Host "Opening installation folder...`n" -ForegroundColor Gray
        
        explorer.exe $installDir

    } catch {
        Write-Host "`n❌ Installation failed: $($_.Exception.Message)" -ForegroundColor Red
    }
}

if ($MyInvocation.InvocationName -eq 'iex' -or $null -eq $MyInvocation.Line) {
    Install-GeetRPCS -Version "portable"
}
