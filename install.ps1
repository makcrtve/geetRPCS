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
    $versionFile = Join-Path $installDir ".version"

    # User data folders that must be retained during updates
    $preserveFolders = @(
        "dev_hdd0", "dev_hdd1", "dev_flash", "dev_flash2", "dev_flash3",
        "dev_bdvd", "dev_usb000", "config", "GuiConfigs", "cache",
        "captures", "Icons", "games", "patches", "savestates", "sounds"
    )

    Write-Host "`n==========================================" -ForegroundColor Cyan
    Write-Host "       geetRPCS Installer / Updater" -ForegroundColor Cyan
    Write-Host "==========================================`n" -ForegroundColor Cyan

    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    try {
        # ══════════════════════════════════════════════════════════════
        # [1/6] CHECK VERSION
        # ══════════════════════════════════════════════════════════════
        Write-Host "[1/6] Checking latest version from GitHub..." -ForegroundColor Yellow
        $releaseInfo = Invoke-RestMethod -Uri "https://api.github.com/repos/$repo/releases/latest" -ErrorAction Stop
        $latestTag = $releaseInfo.tag_name

        # Check the installed version
        $installedVersion = $null
        $isUpdate = $false

        if (Test-Path $versionFile) {
            $versionData = Get-Content $versionFile -Raw | ConvertFrom-Json -ErrorAction SilentlyContinue
            if ($versionData) {
                $installedVersion = $versionData.version
                $installedType = $versionData.type

                if ($installedVersion -eq $latestTag -and $installedType -eq $Version) {
                    Write-Host "`n✅ Already up to date! ($installedVersion - $installedType)" -ForegroundColor Green
                    Write-Host "   Use -Force parameter to reinstall." -ForegroundColor Gray

                    $exePath = Join-Path $installDir $exeName
                    if (Test-Path $exePath) {
                        Write-Host "`nOpening installation folder..." -ForegroundColor Gray
                        explorer.exe $installDir
                    }
                    return
                }

                $isUpdate = $true
                Write-Host "   Installed: $installedVersion ($installedType)" -ForegroundColor DarkGray
                Write-Host "   Available: $latestTag ($Version)" -ForegroundColor DarkGray
            }
        }

        $asset = $releaseInfo.assets | Where-Object { $_.name -like "*$Version.zip" } | Select-Object -First 1
        if (-not $asset) { throw "Could not find the $Version version for release $latestTag" }

        $downloadUrl = $asset.browser_download_url
        $totalSize = $asset.size
        $tempPath = Join-Path $env:TEMP $asset.name
        $tempExtractPath = Join-Path $env:TEMP "geetRPCS_extract_$(Get-Random)"

        # ══════════════════════════════════════════════════════════════
        # [2/6] CLOSE RUNNING INSTANCE
        # ══════════════════════════════════════════════════════════════
        $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
        if ($process) {
            Write-Host "[!] geetRPCS is running. Closing to update..." -ForegroundColor Yellow
            Stop-Process -Name "geetRPCS" -Force
            Start-Sleep -Seconds 2
        }

        # ══════════════════════════════════════════════════════════════
        # [3/6] DOWNLOAD
        # ══════════════════════════════════════════════════════════════
        if ($isUpdate) {
            Write-Host "[2/6] Downloading update ($installedVersion → $latestTag)..." -ForegroundColor Green
        } else {
            Write-Host "[2/6] Downloading $Version version ($latestTag)..." -ForegroundColor Green
        }

        $webClient = New-Object System.Net.WebClient
        $sourceUri = New-Object System.Uri($downloadUrl)

        $startTime = Get-Date
        $webClient.DownloadFileAsync($sourceUri, $tempPath)

        while ($webClient.IsBusy) {
            $stats = Get-Item $tempPath -ErrorAction SilentlyContinue
            if ($stats) {
                $currentSize = $stats.Length

                if ($totalSize -gt 0) { $percent = [Math]::Round(($currentSize / $totalSize) * 100) } else { $percent = 0 }

                $timeElapsed = (Get-Date) - $startTime
                $secondsElapsed = $timeElapsed.TotalSeconds
                $speedBytesPerSec = if ($secondsElapsed -gt 0) { $currentSize / $secondsElapsed } else { 0 }

                $speedMBps = "{0:N2} MB/s" -f ($speedBytesPerSec / 1MB)
                $remainingBytes = $totalSize - $currentSize
                $secondsRemaining = if ($speedBytesPerSec -gt 0) { $remainingBytes / $speedBytesPerSec } else { 0 }
                $etaStr = "{0:mm}:{0:ss}" -f (New-TimeSpan -Seconds $secondsRemaining)

                $currentMB = "{0:N2}" -f ($currentSize / 1MB)
                $totalMB = "{0:N2}" -f ($totalSize / 1MB)

                $barWidth = 15
                $filled = [Math]::Floor(($percent / 100) * $barWidth)
                if ($filled -gt $barWidth) { $filled = $barWidth }
                $progressBar = "[" + ("=" * $filled) + (" " * ($barWidth - $filled)) + "]"

                $msg = "`r$progressBar $currentMB/$totalMB MB ($percent%) @ $speedMBps | ETA: $etaStr    "
                Write-Host -NoNewline $msg -ForegroundColor White
            }
            Start-Sleep -Milliseconds 200
        }
        Write-Host "`n   Download complete!" -ForegroundColor Green

        # ══════════════════════════════════════════════════════════════
        # [4/6] BACKUP USER DATA (if updating)
        # ══════════════════════════════════════════════════════════════
        $backupPath = $null
        if ($isUpdate -and (Test-Path $installDir)) {
            Write-Host "[3/6] Backing up user data..." -ForegroundColor Yellow
            $backupPath = Join-Path $env:TEMP "geetRPCS_backup_$(Get-Random)"
            New-Item -ItemType Directory -Path $backupPath -Force | Out-Null

            $backedUpCount = 0
            foreach ($folder in $preserveFolders) {
                $sourcePath = Join-Path $installDir $folder
                if (Test-Path $sourcePath) {
                    $destPath = Join-Path $backupPath $folder
                    Copy-Item -Path $sourcePath -Destination $destPath -Recurse -Force
                    $backedUpCount++
                    Write-Host "      ├─ $folder" -ForegroundColor DarkGray
                }
            }

            if ($backedUpCount -eq 0) {
                Write-Host "      └─ No user data found" -ForegroundColor DarkGray
            } else {
                Write-Host "      └─ Backed up $backedUpCount folders" -ForegroundColor DarkGray
            }
        } else {
            Write-Host "[3/6] Fresh installation (no backup needed)" -ForegroundColor Yellow
        }

        # ══════════════════════════════════════════════════════════════
        # [5/6] EXTRACT & INSTALL
        # ══════════════════════════════════════════════════════════════
        Write-Host "[4/6] Extracting files..." -ForegroundColor Yellow

        # Extract to the temp folder first
        New-Item -ItemType Directory -Path $tempExtractPath -Force | Out-Null
        Expand-Archive -Path $tempPath -DestinationPath $tempExtractPath -Force
        Remove-Item $tempPath -Force

        # Find the extracted folder
        $extractedContent = Get-ChildItem -Path $tempExtractPath
        $sourceDir = $tempExtractPath

        # If the extract result is a single folder, use its contents.
        if ($extractedContent.Count -eq 1 -and $extractedContent[0].PSIsContainer) {
            $sourceDir = $extractedContent[0].FullName
            Write-Host "      └─ Found: $($extractedContent[0].Name)" -ForegroundColor DarkGray
        }

        # Delete the old folder (if any)
        if (Test-Path $installDir) {
            Write-Host "[5/6] Cleaning old installation..." -ForegroundColor Yellow

            # Delete everything except what is preserved (will be restored from backup)
            Get-ChildItem -Path $installDir -Force | ForEach-Object {
                $itemName = $_.Name
                if ($preserveFolders -notcontains $itemName -and $itemName -ne ".version") {
                    Remove-Item -Path $_.FullName -Recurse -Force -ErrorAction SilentlyContinue
                }
            }

            # Also delete the preserved folder (it will be restored from the backup)
            foreach ($folder in $preserveFolders) {
                $folderPath = Join-Path $installDir $folder
                if (Test-Path $folderPath) {
                    Remove-Item -Path $folderPath -Recurse -Force -ErrorAction SilentlyContinue
                }
            }
        } else {
            Write-Host "[5/6] Creating installation directory..." -ForegroundColor Yellow
            New-Item -ItemType Directory -Path $installDir -Force | Out-Null
        }

        # Copy the new file to the install directory
        Write-Host "      └─ Installing to: $installDir" -ForegroundColor DarkGray
        Copy-Item -Path "$sourceDir\*" -Destination $installDir -Recurse -Force

        # Cleanup temp extract folder
        Remove-Item -Path $tempExtractPath -Recurse -Force -ErrorAction SilentlyContinue

        # ══════════════════════════════════════════════════════════════
        # RESTORE USER DATA
        # ══════════════════════════════════════════════════════════════
        if ($backupPath -and (Test-Path $backupPath)) {
            Write-Host "      └─ Restoring user data..." -ForegroundColor DarkGray
            Copy-Item -Path "$backupPath\*" -Destination $installDir -Recurse -Force
            Remove-Item -Path $backupPath -Recurse -Force -ErrorAction SilentlyContinue
        }

        # Unblock files
        Get-ChildItem -Path $installDir -Recurse -File | Unblock-File -ErrorAction SilentlyContinue

        # Verify executable exists
        $exePath = Join-Path $installDir $exeName
        if (-not (Test-Path $exePath)) {
            throw "File $exeName not found after extraction!"
        }

        # ══════════════════════════════════════════════════════════════
        # SAVE VERSION INFO
        # ══════════════════════════════════════════════════════════════
        $versionData = @{
            version = $latestTag
            type = $Version
            installedAt = (Get-Date).ToString("yyyy-MM-dd HH:mm:ss")
        }
        $versionData | ConvertTo-Json | Set-Content -Path $versionFile -Force

        # ══════════════════════════════════════════════════════════════
        # [6/6] CREATE SHORTCUT (if requested)
        # ══════════════════════════════════════════════════════════════
        if ($DesktopShortcut) {
            Write-Host "[6/6] Creating Desktop shortcut..." -ForegroundColor Yellow

            $desktopPath = [Environment]::GetFolderPath("Desktop")
            $shortcutPath = Join-Path $desktopPath "geetRPCS.lnk"

            if (Test-Path $shortcutPath) { Remove-Item $shortcutPath -Force }

            $WshShell = New-Object -ComObject WScript.Shell
            $Shortcut = $WshShell.CreateShortcut($shortcutPath)
            $Shortcut.TargetPath = $exePath
            $Shortcut.WorkingDirectory = $installDir
            $Shortcut.IconLocation = "$exePath,0"
            $Shortcut.Save()

            if (Get-Command "ie4uinit.exe" -ErrorAction SilentlyContinue) {
                & "ie4uinit.exe" -show 2>$null
            }
        } else {
            Write-Host "[6/6] Skipping shortcut creation" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # DONE
        # ══════════════════════════════════════════════════════════════
        Write-Host "`n==========================================" -ForegroundColor Green
        if ($isUpdate) {
            Write-Host "  ✅ Update completed successfully!" -ForegroundColor Green
            Write-Host "     $installedVersion → $latestTag" -ForegroundColor White
        } else {
            Write-Host "  ✅ Installation completed successfully!" -ForegroundColor Green
            Write-Host "     Version: $latestTag ($Version)" -ForegroundColor White
        }
        Write-Host "==========================================" -ForegroundColor Green
        Write-Host "LOCATION: $installDir" -ForegroundColor Cyan
        Write-Host "==========================================`n" -ForegroundColor Green

        Write-Host "Opening installation folder..." -ForegroundColor Gray
        explorer.exe $installDir

    } catch {
        Write-Host "`n❌ Installation failed: $($_.Exception.Message)" -ForegroundColor Red

        # Cleanup on failure
        if ($tempPath -and (Test-Path $tempPath)) {
            Remove-Item $tempPath -Force -ErrorAction SilentlyContinue
        }
        if ($tempExtractPath -and (Test-Path $tempExtractPath)) {
            Remove-Item $tempExtractPath -Recurse -Force -ErrorAction SilentlyContinue
        }
    }
}

# Auto-run when invoked via iex
if ($MyInvocation.InvocationName -eq 'iex' -or
    $MyInvocation.InvocationName -eq '&' -or
    $null -eq $MyInvocation.Line -or
    $MyInvocation.Line -match 'iex') {
    Install-GeetRPCS -Version "portable"
}
