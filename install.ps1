function Install-GeetRPCS {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [ValidateSet("minimal", "portable")]
        [string]$Version = "",

        [Parameter(Mandatory=$false)]
        [switch]$DesktopShortcut,

        [Parameter(Mandatory=$false)]
        [switch]$StartMenuShortcut,

        [Parameter(Mandatory=$false)]
        [switch]$ResetAppsJson,

        [Parameter(Mandatory=$false)]
        [switch]$Silent
    )

    $repo = "makcrtve/geetRPCS"
    $installDir = "$env:LOCALAPPDATA\geetRPCS"
    $exeName = "geetRPCS.exe"
    $versionFile = Join-Path $installDir ".version"

    $preserveFolders = @(
        "ImageCache", "Languages"
    )

    $preserveFiles = @(
        "settings.json"
    )

    $appsJsonPath = Join-Path $installDir "apps.json"

    # ══════════════════════════════════════════════════════════════
    # HELPER FUNCTION: Show Menu
    # ══════════════════════════════════════════════════════════════
    function Show-Menu {
        param (
            [string]$Title,
            [string[]]$Options,
            [int]$Default = 0
        )

        Write-Host "`n$Title" -ForegroundColor Cyan
        for ($i = 0; $i -lt $Options.Count; $i++) {
            if ($i -eq $Default) {
                Write-Host "  [$($i + 1)] $($Options[$i]) " -NoNewline
                Write-Host "(default)" -ForegroundColor DarkGray
            } else {
                Write-Host "  [$($i + 1)] $($Options[$i])"
            }
        }

        $selection = Read-Host "`nEnter choice [1-$($Options.Count)]"

        if ([string]::IsNullOrWhiteSpace($selection)) {
            return $Default
        }

        $index = 0
        if ([int]::TryParse($selection, [ref]$index)) {
            if ($index -ge 1 -and $index -le $Options.Count) {
                return $index - 1
            }
        }

        return $Default
    }

    function Show-YesNo {
        param (
            [string]$Question,
            [bool]$Default = $true
        )

        $defaultText = if ($Default) { "Y/n" } else { "y/N" }
        $response = Read-Host "$Question [$defaultText]"

        if ([string]::IsNullOrWhiteSpace($response)) {
            return $Default
        }

        return $response.ToLower() -eq 'y' -or $response.ToLower() -eq 'yes'
    }

    # ══════════════════════════════════════════════════════════════
    # HEADER
    # ══════════════════════════════════════════════════════════════
    Clear-Host
    Write-Host ""
    Write-Host "  ╔═══════════════════════════════════════════╗" -ForegroundColor Cyan
    Write-Host "  ║                                           ║" -ForegroundColor Cyan
    Write-Host "  ║       geetRPCS Installer / Updater        ║" -ForegroundColor Cyan
    Write-Host "  ║                                           ║" -ForegroundColor Cyan
    Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Cyan
    Write-Host ""

    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

    try {
        # ══════════════════════════════════════════════════════════════
        # INTERACTIVE MENU (if not Silent mode)
        # ══════════════════════════════════════════════════════════════
        if (-not $Silent) {
            if ([string]::IsNullOrWhiteSpace($Version)) {
                $versionOptions = @(
                    "Portable (Recommended) - Standalone, no dependencies",
                    "Minimal - Smaller size, requires .NET 8.0 Runtime"
                )
                $versionChoice = Show-Menu -Title "Select Version:" -Options $versionOptions -Default 0
                $Version = if ($versionChoice -eq 0) { "portable" } else { "minimal" }
            }

            if (-not $PSBoundParameters.ContainsKey('DesktopShortcut')) {
                $DesktopShortcut = Show-YesNo -Question "Create Desktop shortcut?" -Default $true
            }

            if (-not $PSBoundParameters.ContainsKey('StartMenuShortcut')) {
                $StartMenuShortcut = Show-YesNo -Question "Create Start Menu shortcut?" -Default $true
            }

            if ((Test-Path $appsJsonPath) -and -not $PSBoundParameters.ContainsKey('ResetAppsJson')) {
                Write-Host ""
                Write-Host "⚠️  apps.json file detected" -ForegroundColor Yellow
                $ResetAppsJson = Show-YesNo -Question "Reset apps.json to default? (No = keep current)" -Default $false
            }

            Write-Host ""
        } else {
            if ([string]::IsNullOrWhiteSpace($Version)) {
                $Version = "portable"
            }
        }

        # ══════════════════════════════════════════════════════════════
        # [1/7] CHECK VERSION
        # ══════════════════════════════════════════════════════════════
        Write-Host "[1/7] Checking latest version from GitHub..." -ForegroundColor Yellow
        $releaseInfo = Invoke-RestMethod -Uri "https://api.github.com/repos/$repo/releases/latest" -ErrorAction Stop
        $latestTag = $releaseInfo.tag_name

        $installedVersion = $null
        $isUpdate = $false

        if (Test-Path $versionFile) {
            $versionData = Get-Content $versionFile -Raw | ConvertFrom-Json -ErrorAction SilentlyContinue
            if ($versionData) {
                $installedVersion = $versionData.version
                $installedType = $versionData.type

                if ($installedVersion -eq $latestTag -and $installedType -eq $Version -and -not $ResetAppsJson) {
                    Write-Host "`n✅ Already up to date! ($installedVersion - $installedType)" -ForegroundColor Green

                    $exePath = Join-Path $installDir $exeName
                    if (Test-Path $exePath) {
                        Write-Host "`nOpening installation folder..." -ForegroundColor Gray
                        explorer.exe $installDir
                    }
                    return
                }

                $isUpdate = $true
                Write-Host "      Installed: $installedVersion ($installedType)" -ForegroundColor DarkGray
                Write-Host "      Available: $latestTag ($Version)" -ForegroundColor DarkGray
            }
        }

        $asset = $releaseInfo.assets | Where-Object { $_.name -like "*$Version.zip" } | Select-Object -First 1
        if (-not $asset) { throw "Could not find the $Version version for release $latestTag" }

        $downloadUrl = $asset.browser_download_url
        $totalSize = $asset.size
        $tempPath = Join-Path $env:TEMP $asset.name
        $tempExtractPath = Join-Path $env:TEMP "geetRPCS_extract_$(Get-Random)"

        # ══════════════════════════════════════════════════════════════
        # [2/7] CLOSE RUNNING INSTANCE
        # ══════════════════════════════════════════════════════════════
        $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
        if ($process) {
            Write-Host "[2/7] geetRPCS is running. Closing..." -ForegroundColor Yellow
            Stop-Process -Name "geetRPCS" -Force
            Start-Sleep -Seconds 2
        } else {
            Write-Host "[2/7] No running instance found" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # [3/7] DOWNLOAD
        # ══════════════════════════════════════════════════════════════
        if ($isUpdate) {
            Write-Host "[3/7] Downloading update ($installedVersion → $latestTag)..." -ForegroundColor Green
        } else {
            Write-Host "[3/7] Downloading $Version version ($latestTag)..." -ForegroundColor Green
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

                $barWidth = 20
                $filled = [Math]::Floor(($percent / 100) * $barWidth)
                if ($filled -gt $barWidth) { $filled = $barWidth }
                $progressBar = "[" + ("█" * $filled) + ("░" * ($barWidth - $filled)) + "]"

                $msg = "`r      $progressBar $currentMB/$totalMB MB ($percent%) @ $speedMBps | ETA: $etaStr    "
                Write-Host -NoNewline $msg -ForegroundColor White
            }
            Start-Sleep -Milliseconds 200
        }
        Write-Host "`n      Download complete!" -ForegroundColor Green

        # ══════════════════════════════════════════════════════════════
        # [4/7] BACKUP USER DATA (if updating)
        # ══════════════════════════════════════════════════════════════
        $backupPath = $null
        if ($isUpdate -and (Test-Path $installDir)) {
            Write-Host "[4/7] Backing up user data..." -ForegroundColor Yellow
            $backupPath = Join-Path $env:TEMP "geetRPCS_backup_$(Get-Random)"
            New-Item -ItemType Directory -Path $backupPath -Force | Out-Null

            $backedUpCount = 0

            foreach ($folder in $preserveFolders) {
                $sourcePath = Join-Path $installDir $folder
                if (Test-Path $sourcePath) {
                    $destPath = Join-Path $backupPath $folder
                    Copy-Item -Path $sourcePath -Destination $destPath -Recurse -Force
                    $backedUpCount++
                    Write-Host "      ├─ 📁 $folder" -ForegroundColor DarkGray
                }
            }

            foreach ($file in $preserveFiles) {
                $sourcePath = Join-Path $installDir $file
                if (Test-Path $sourcePath) {
                    $destPath = Join-Path $backupPath $file

                    $destDir = Split-Path $destPath -Parent
                    if (-not (Test-Path $destDir)) {
                        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
                    }
                    Copy-Item -Path $sourcePath -Destination $destPath -Force
                    $backedUpCount++
                    Write-Host "      ├─ 📄 $file" -ForegroundColor DarkGray
                }
            }

            if (-not $ResetAppsJson -and (Test-Path $appsJsonPath)) {
                $destPath = Join-Path $backupPath "apps.json"
                Copy-Item -Path $appsJsonPath -Destination $destPath -Force
                $backedUpCount++
                Write-Host "      ├─ 📄 apps.json (keeping current)" -ForegroundColor DarkGray
            } elseif ($ResetAppsJson -and (Test-Path $appsJsonPath)) {
                Write-Host "      ├─ 🔄 apps.json (will be reset to default)" -ForegroundColor Yellow
            }

            if ($backedUpCount -eq 0) {
                Write-Host "      └─ No user data found" -ForegroundColor DarkGray
            } else {
                Write-Host "      └─ Backed up $backedUpCount items" -ForegroundColor DarkGray
            }
        } else {
            Write-Host "[4/7] Fresh installation (no backup needed)" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # [5/7] EXTRACT & INSTALL
        # ══════════════════════════════════════════════════════════════
        Write-Host "[5/7] Extracting files..." -ForegroundColor Yellow

        New-Item -ItemType Directory -Path $tempExtractPath -Force | Out-Null
        Expand-Archive -Path $tempPath -DestinationPath $tempExtractPath -Force
        Remove-Item $tempPath -Force

        $extractedContent = Get-ChildItem -Path $tempExtractPath
        $sourceDir = $tempExtractPath

        if ($extractedContent.Count -eq 1 -and $extractedContent[0].PSIsContainer) {
            $sourceDir = $extractedContent[0].FullName
            Write-Host "      └─ Found: $($extractedContent[0].Name)" -ForegroundColor DarkGray
        }

        if (Test-Path $installDir) {
            Write-Host "[6/7] Cleaning old installation..." -ForegroundColor Yellow
            Remove-Item -Path $installDir -Recurse -Force -ErrorAction SilentlyContinue
        } else {
            Write-Host "[6/7] Creating installation directory..." -ForegroundColor Yellow
        }

        New-Item -ItemType Directory -Path $installDir -Force | Out-Null

        Write-Host "      └─ Installing to: $installDir" -ForegroundColor DarkGray
        Copy-Item -Path "$sourceDir\*" -Destination $installDir -Recurse -Force

        Remove-Item -Path $tempExtractPath -Recurse -Force -ErrorAction SilentlyContinue

        # ══════════════════════════════════════════════════════════════
        # RESTORE USER DATA
        # ══════════════════════════════════════════════════════════════
        if ($backupPath -and (Test-Path $backupPath)) {
            Write-Host "      └─ Restoring user data..." -ForegroundColor DarkGray

            foreach ($folder in $preserveFolders) {
                $sourcePath = Join-Path $backupPath $folder
                if (Test-Path $sourcePath) {
                    $destPath = Join-Path $installDir $folder
                    Copy-Item -Path $sourcePath -Destination $destPath -Recurse -Force
                }
            }

            foreach ($file in $preserveFiles) {
                $sourcePath = Join-Path $backupPath $file
                if (Test-Path $sourcePath) {
                    $destPath = Join-Path $installDir $file
                    Copy-Item -Path $sourcePath -Destination $destPath -Force
                }
            }

            if (-not $ResetAppsJson) {
                $appsJsonBackup = Join-Path $backupPath "apps.json"
                if (Test-Path $appsJsonBackup) {
                    Copy-Item -Path $appsJsonBackup -Destination $appsJsonPath -Force
                    Write-Host "         ✅ apps.json restored" -ForegroundColor Green
                }
            } else {
                Write-Host "         ✅ apps.json reset to default" -ForegroundColor Green
            }

            Remove-Item -Path $backupPath -Recurse -Force -ErrorAction SilentlyContinue
        }

        Get-ChildItem -Path $installDir -Recurse -File | Unblock-File -ErrorAction SilentlyContinue

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
        # [7/7] CREATE SHORTCUTS
        # ══════════════════════════════════════════════════════════════
        Write-Host "[7/7] Creating shortcuts..." -ForegroundColor Yellow

        $shortcutsCreated = @()

        if ($DesktopShortcut) {
            $desktopPath = [Environment]::GetFolderPath("Desktop")
            $shortcutPath = Join-Path $desktopPath "geetRPCS.lnk"

            if (Test-Path $shortcutPath) { Remove-Item $shortcutPath -Force }

            $WshShell = New-Object -ComObject WScript.Shell
            $Shortcut = $WshShell.CreateShortcut($shortcutPath)
            $Shortcut.TargetPath = $exePath
            $Shortcut.WorkingDirectory = $installDir
            $Shortcut.IconLocation = "$exePath,0"
            $Shortcut.Description = "geetRPCS - PS3 Games Library Manager"
            $Shortcut.Save()

            $shortcutsCreated += "Desktop"
            Write-Host "      ├─ ✅ Desktop shortcut" -ForegroundColor DarkGray
        }

        if ($StartMenuShortcut) {
            $startMenuPath = Join-Path $env:APPDATA "Microsoft\Windows\Start Menu\Programs"
            $startMenuFolder = Join-Path $startMenuPath "geetRPCS"

            if (-not (Test-Path $startMenuFolder)) {
                New-Item -ItemType Directory -Path $startMenuFolder -Force | Out-Null
            }

            $shortcutPath = Join-Path $startMenuFolder "geetRPCS.lnk"

            if (Test-Path $shortcutPath) { Remove-Item $shortcutPath -Force }

            $WshShell = New-Object -ComObject WScript.Shell
            $Shortcut = $WshShell.CreateShortcut($shortcutPath)
            $Shortcut.TargetPath = $exePath
            $Shortcut.WorkingDirectory = $installDir
            $Shortcut.IconLocation = "$exePath,0"
            $Shortcut.Description = "geetRPCS - PS3 Games Library Manager"
            $Shortcut.Save()

            $uninstallShortcutPath = Join-Path $startMenuFolder "Uninstall geetRPCS.lnk"
            $UninstallShortcut = $WshShell.CreateShortcut($uninstallShortcutPath)
            $UninstallShortcut.TargetPath = "powershell.exe"
            $UninstallShortcut.Arguments = "-NoProfile -ExecutionPolicy Bypass -Command `"Remove-Item -Path '$installDir' -Recurse -Force; Remove-Item -Path '$startMenuFolder' -Recurse -Force; Remove-Item -Path '$([Environment]::GetFolderPath('Desktop'))\geetRPCS.lnk' -Force -ErrorAction SilentlyContinue; Write-Host 'geetRPCS has been uninstalled.' -ForegroundColor Green; Start-Sleep -Seconds 2`""
            $UninstallShortcut.IconLocation = "shell32.dll,31"
            $UninstallShortcut.Description = "Uninstall geetRPCS"
            $UninstallShortcut.Save()

            $shortcutsCreated += "Start Menu"
            Write-Host "      ├─ ✅ Start Menu shortcut" -ForegroundColor DarkGray
            Write-Host "      ├─ ✅ Uninstall shortcut" -ForegroundColor DarkGray
        }

        if ($shortcutsCreated.Count -eq 0) {
            Write-Host "      └─ No shortcuts created" -ForegroundColor DarkGray
        } else {
            Write-Host "      └─ Created: $($shortcutsCreated -join ', ')" -ForegroundColor DarkGray
        }

        if (Get-Command "ie4uinit.exe" -ErrorAction SilentlyContinue) {
            & "ie4uinit.exe" -show 2>$null
        }

        # ══════════════════════════════════════════════════════════════
        # DONE
        # ══════════════════════════════════════════════════════════════
        Write-Host ""
        Write-Host "  ╔═══════════════════════════════════════════╗" -ForegroundColor Green
        if ($isUpdate) {
            Write-Host "  ║     ✅ Update completed successfully!    ║" -ForegroundColor Green
            Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Green
            Write-Host ""
            Write-Host "  $installedVersion → $latestTag ($Version)" -ForegroundColor White
        } else {
            Write-Host "  ║  ✅ Installation completed successfully! ║" -ForegroundColor Green
            Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Green
            Write-Host ""
            Write-Host "  Version: $latestTag ($Version)" -ForegroundColor White
        }
        Write-Host ""
        Write-Host "  📁 Location: $installDir" -ForegroundColor Cyan
        if ($ResetAppsJson) {
            Write-Host "  🔄 apps.json has been reset to default" -ForegroundColor Yellow
        }
        Write-Host ""

        Write-Host "Opening installation folder..." -ForegroundColor Gray
        explorer.exe $installDir

    } catch {
        Write-Host "`n❌ Installation failed: $($_.Exception.Message)" -ForegroundColor Red

        if ($tempPath -and (Test-Path $tempPath)) {
            Remove-Item $tempPath -Force -ErrorAction SilentlyContinue
        }
        if ($tempExtractPath -and (Test-Path $tempExtractPath)) {
            Remove-Item $tempExtractPath -Recurse -Force -ErrorAction SilentlyContinue
        }
    }
}

Install-GeetRPCS
