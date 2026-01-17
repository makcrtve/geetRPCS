function Uninstall-GeetRPCS {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false)]
        [switch]$Silent,

        [Parameter(Mandatory = $false)]
        [switch]$KeepUserData
    )

    $installDir = "$env:LOCALAPPDATA\geetRPCS"
    $desktopShortcut = Join-Path ([Environment]::GetFolderPath("Desktop")) "geetRPCS.lnk"
    $startMenuFolder = Join-Path $env:APPDATA "Microsoft\Windows\Start Menu\Programs\geetRPCS"

    # ══════════════════════════════════════════════════════════════
    # HELPER FUNCTION: Show Yes/No Prompt
    # ══════════════════════════════════════════════════════════════
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
    Write-Host "  ╔═══════════════════════════════════════════╗" -ForegroundColor Red
    Write-Host "  ║                                           ║" -ForegroundColor Red
    Write-Host "  ║         geetRPCS Uninstaller              ║" -ForegroundColor Red
    Write-Host "  ║                                           ║" -ForegroundColor Red
    Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Red
    Write-Host ""

    # ══════════════════════════════════════════════════════════════
    # CHECK IF INSTALLED
    # ══════════════════════════════════════════════════════════════
    if (-not (Test-Path $installDir)) {
        Write-Host "  ⚠️  geetRPCS is not installed." -ForegroundColor Yellow
        Write-Host "  📁 Expected location: $installDir" -ForegroundColor DarkGray
        Write-Host ""
        return
    }

    # Show current installation info
    $versionFile = Join-Path $installDir ".version"
    if (Test-Path $versionFile) {
        $versionData = Get-Content $versionFile -Raw | ConvertFrom-Json -ErrorAction SilentlyContinue
        if ($versionData) {
            Write-Host "  📦 Installed Version: $($versionData.version) ($($versionData.type))" -ForegroundColor Cyan
            Write-Host "  📅 Installed At: $($versionData.installedAt)" -ForegroundColor DarkGray
            Write-Host ""
        }
    }

    # ══════════════════════════════════════════════════════════════
    # CONFIRMATION (if not Silent)
    # ══════════════════════════════════════════════════════════════
    if (-not $Silent) {
        $confirm = Show-YesNo -Question "  Are you sure you want to uninstall geetRPCS?" -Default $false
        if (-not $confirm) {
            Write-Host ""
            Write-Host "  ❌ Uninstallation cancelled." -ForegroundColor Yellow
            Write-Host ""
            return
        }

        if (-not $PSBoundParameters.ContainsKey('KeepUserData')) {
            Write-Host ""
            $KeepUserData = Show-YesNo -Question "  Keep user data (settings.json, statistics.json)?" -Default $false
        }

        Write-Host ""
    }

    try {
        # ══════════════════════════════════════════════════════════════
        # [1/4] CLOSE RUNNING INSTANCE
        # ══════════════════════════════════════════════════════════════
        $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
        if ($process) {
            Write-Host "[1/4] Closing running instance..." -ForegroundColor Yellow
            Stop-Process -Name "geetRPCS" -Force
            Start-Sleep -Seconds 2
            Write-Host "      └─ ✅ Process terminated" -ForegroundColor DarkGray
        }
        else {
            Write-Host "[1/4] No running instance found" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # [2/4] BACKUP USER DATA (if KeepUserData)
        # ══════════════════════════════════════════════════════════════
        $backupDir = $null
        if ($KeepUserData) {
            Write-Host "[2/4] Backing up user data..." -ForegroundColor Yellow
            $backupDir = Join-Path $env:TEMP "geetRPCS_backup_$(Get-Date -Format 'yyyyMMdd_HHmmss')"
            New-Item -ItemType Directory -Path $backupDir -Force | Out-Null

            $filesToBackup = @("settings.json", "statistics.json", "apps.json", "config.json", "witty.json")
            $backed = 0

            foreach ($file in $filesToBackup) {
                $filePath = Join-Path $installDir $file
                if (Test-Path $filePath) {
                    Copy-Item -Path $filePath -Destination $backupDir -Force
                    $backed++
                }
            }

            if ($backed -gt 0) {
                Write-Host "      └─ ✅ Backed up $backed files to $backupDir" -ForegroundColor DarkGray
            }
            else {
                Write-Host "      └─ No user data found to backup" -ForegroundColor DarkGray
            }
        }
        else {
            Write-Host "[2/4] Skipping backup (user data will be deleted)" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # [3/4] REMOVE SHORTCUTS
        # ══════════════════════════════════════════════════════════════
        Write-Host "[3/4] Removing shortcuts..." -ForegroundColor Yellow

        $shortcutsRemoved = 0

        if (Test-Path $desktopShortcut) {
            Remove-Item $desktopShortcut -Force
            $shortcutsRemoved++
            Write-Host "      ├─ ✅ Desktop shortcut" -ForegroundColor DarkGray
        }

        if (Test-Path $startMenuFolder) {
            Remove-Item $startMenuFolder -Recurse -Force
            $shortcutsRemoved++
            Write-Host "      ├─ ✅ Start Menu folder" -ForegroundColor DarkGray
        }

        if ($shortcutsRemoved -eq 0) {
            Write-Host "      └─ No shortcuts found" -ForegroundColor DarkGray
        }
        else {
            Write-Host "      └─ Removed $shortcutsRemoved shortcut(s)" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # [4/4] REMOVE INSTALLATION DIRECTORY
        # ══════════════════════════════════════════════════════════════
        Write-Host "[4/4] Removing installation directory..." -ForegroundColor Yellow

        Remove-Item -Path $installDir -Recurse -Force -ErrorAction Stop
        Write-Host "      └─ ✅ Removed: $installDir" -ForegroundColor DarkGray

        # ══════════════════════════════════════════════════════════════
        # REMOVE STARTUP REGISTRY (if exists)
        # ══════════════════════════════════════════════════════════════
        $registryPath = "HKCU:\Software\Microsoft\Windows\CurrentVersion\Run"
        $registryName = "geetRPCS"

        if (Get-ItemProperty -Path $registryPath -Name $registryName -ErrorAction SilentlyContinue) {
            Remove-ItemProperty -Path $registryPath -Name $registryName -ErrorAction SilentlyContinue
            Write-Host "      └─ ✅ Removed startup registry entry" -ForegroundColor DarkGray
        }

        # ══════════════════════════════════════════════════════════════
        # DONE
        # ══════════════════════════════════════════════════════════════
        Write-Host ""
        Write-Host "  ╔═══════════════════════════════════════════╗" -ForegroundColor Green
        Write-Host "  ║  ✅ Uninstallation completed successfully! ║" -ForegroundColor Green
        Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Green
        Write-Host ""

        if ($KeepUserData -and $backupDir) {
            Write-Host "  📁 User data backup: $backupDir" -ForegroundColor Cyan
            Write-Host ""
        }

        Write-Host "  Thank you for using geetRPCS! 👋" -ForegroundColor Magenta
        Write-Host ""

    }
    catch {
        Write-Host ""
        Write-Host "  ❌ Uninstallation failed: $($_.Exception.Message)" -ForegroundColor Red
        Write-Host ""
    }
}

Uninstall-GeetRPCS
