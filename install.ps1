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
        $totalSize = $asset.size
        $tempPath = Join-Path $env:TEMP $asset.name

        $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
        if ($process) {
            Write-Host "[!] geetRPCS is running. Closing to update..." -ForegroundColor Yellow
            Stop-Process -Name "geetRPCS" -Force
            Start-Sleep -Seconds 1
        }

        Write-Host "[2/5] Downloading $Version version ($tag)..." -ForegroundColor Green
        
        $webClient = New-Object System.Net.WebClient
        $sourceUri = New-Object System.Uri($downloadUrl)
        
        $startTick = Get-Date
        $webClient.DownloadFileAsync($sourceUri, $tempPath)

        while ($webClient.IsBusy) {
            $stats = Get-Item $tempPath -ErrorAction SilentlyContinue
            if ($stats) {
                $currentSize = $stats.Length
                $percent = [Math]::Round(($currentSize / $totalSize) * 100)
                $currentMB = [Math]::Round($currentSize / 1MB, 2)
                $totalMB = [Math]::Round($totalSize / 1MB, 2)
                
                $msg = "`r[Progress] $currentMB MB / $totalMB MB ($percent%)"
                Write-Host -NoNewline $msg -ForegroundColor White
            }
            Start-Sleep -Milliseconds 200
        }
        Write-Host "`nDownload complete!" -ForegroundColor Green

        if (-not (Test-Path $installDir)) { New-Item -ItemType Directory -Path $installDir -Force | Out-Null }
        Write-Host "[3/5] Extracting files..." -ForegroundColor Yellow
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
        }

        Write-Host "[5/5] Finalizing installation..." -ForegroundColor Yellow
        Start-Sleep -Seconds 1

        Write-Host "`n✅ Installation completed successfully!" -ForegroundColor Green
        Write-Host "--------------------------------------------------" -ForegroundColor Cyan
        Write-Host "LOCATION: $installDir" -ForegroundColor White
        Write-Host "--------------------------------------------------" -ForegroundColor Cyan
        
        Write-Host "Opening installation folder..." -ForegroundColor Gray
        explorer.exe $installDir

    } catch {
        Write-Host "`n❌ Installation failed: $($_.Exception.Message)" -ForegroundColor Red
    }
}

if ($MyInvocation.InvocationName -eq 'iex' -or $null -eq $MyInvocation.Line) {
    Install-GeetRPCS -Version "portable"
}
