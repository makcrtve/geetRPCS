function Uninstall-GeetRPCS {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$false)]
        [switch]$Silent,

        [Parameter(Mandatory=$false)]
        [switch]$KeepUserData
    )

    $installDir = "$env:LOCALAPPDATA\geetRPCS"
    $startMenuFolder = Join-Path $env:APPDATA "Microsoft\Windows\Start Menu\Programs\geetRPCS"
    $desktopShortcut = Join-Path ([Environment]::GetFolderPath("Desktop")) "geetRPCS.lnk"

    # User data yang bisa dipertahankan
    $userDataFolders = @("ImageCache", "Languages")
    $userDataFiles = @("apps.json", "settings.json")

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
    # CHECK INSTALLATION
    # ══════════════════════════════════════════════════════════════
    if (-not (Test-Path $installDir)) {
        Write-Host "  ⚠️  geetRPCS is not installed." -ForegroundColor Yellow
        Write-Host ""
        Write-Host "  Expected location: $installDir" -ForegroundColor DarkGray
        Write-Host ""
        return
    }

    # Get installed version info
    $versionFile = Join-Path $installDir ".version"
    $versionInfo = ""
    if (Test-Path $versionFile) {
        $versionData = Get-Content $versionFile -Raw | ConvertFrom-Json -ErrorAction SilentlyContinue
        if ($versionData) {
            $versionInfo = "$($versionData.version) ($($versionData.type))"
        }
    }

    # Calculate folder size
    $folderSize = (Get-ChildItem -Path $installDir -Recurse -File | Measure-Object -Property Length -Sum).Sum
    $folderSizeMB = "{0:N2} MB" -f ($folderSize / 1MB)

    # ══════════════════════════════════════════════════════════════
    # SHOW INFO
    # ══════════════════════════════════════════════════════════════
    Write-Host "  📁 Installation found:" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "     Location : $installDir" -ForegroundColor White
    if ($versionInfo) {
        Write-Host "     Version  : $versionInfo" -ForegroundColor White
    }
    Write-Host "     Size     : $folderSizeMB" -ForegroundColor White
    Write-Host ""

    # Check what will be removed
    $itemsToRemove = @()

    if (Test-Path $installDir) {
        $itemsToRemove += "📁 Installation folder"
    }
    if (Test-Path $desktopShortcut) {
        $itemsToRemove += "🔗 Desktop shortcut"
    }
    if (Test-Path $startMenuFolder) {
        $itemsToRemove += "🔗 Start Menu folder"
    }

    Write-Host "  The following will be removed:" -ForegroundColor Yellow
    foreach ($item in $itemsToRemove) {
        Write-Host "     • $item" -ForegroundColor DarkGray
    }
    Write-Host ""

    # ══════════════════════════════════════════════════════════════
    # CONFIRMATION
    # ══════════════════════════════════════════════════════════════
    if (-not $Silent) {
        # Ask about keeping user data
        if (-not $PSBoundParameters.ContainsKey('KeepUserData')) {
            Write-Host "  Do you want to keep user data (settings, cache)?" -ForegroundColor Cyan
            Write-Host "     [Y] Yes - Keep apps.json, settings.json, etc." -ForegroundColor DarkGray
            Write-Host "     [N] No  - Remove everything (clean uninstall)" -ForegroundColor DarkGray
            Write-Host ""
            $keepDataResponse = Read-Host "  Keep user data? [y/N]"
            $KeepUserData = $keepDataResponse.ToLower() -eq 'y' -or $keepDataResponse.ToLower() -eq 'yes'
        }

        Write-Host ""
        Write-Host "  ⚠️  WARNING: This action cannot be undone!" -ForegroundColor Red
        Write-Host ""
        $confirm = Read-Host "  Type 'UNINSTALL' to confirm"

        if ($confirm -ne 'UNINSTALL') {
            Write-Host ""
            Write-Host "  ❌ Uninstallation cancelled." -ForegroundColor Yellow
            Write-Host ""
            return
        }
    }

    Write-Host ""

    # ══════════════════════════════════════════════════════════════
    # CLOSE RUNNING INSTANCE
    # ══════════════════════════════════════════════════════════════
    $process = Get-Process | Where-Object { $_.ProcessName -eq "geetRPCS" }
    if ($process) {
        Write-Host "  [1/4] Closing geetRPCS..." -ForegroundColor Yellow
        Stop-Process -Name "geetRPCS" -Force -ErrorAction SilentlyContinue
        Start-Sleep -Seconds 2
    } else {
        Write-Host "  [1/4] No running instance" -ForegroundColor DarkGray
    }

    # ══════════════════════════════════════════════════════════════
    # BACKUP USER DATA (if requested)
    # ══════════════════════════════════════════════════════════════
    $backupPath = $null
    if ($KeepUserData) {
        Write-Host "  [2/4] Backing up user data..." -ForegroundColor Yellow
        $backupPath = Join-Path $env:TEMP "geetRPCS_userdata_backup"

        if (Test-Path $backupPath) {
            Remove-Item -Path $backupPath -Recurse -Force -ErrorAction SilentlyContinue
        }
        New-Item -ItemType Directory -Path $backupPath -Force | Out-Null

        $backedUp = 0
        foreach ($folder in $userDataFolders) {
            $sourcePath = Join-Path $installDir $folder
            if (Test-Path $sourcePath) {
                Copy-Item -Path $sourcePath -Destination (Join-Path $backupPath $folder) -Recurse -Force
                $backedUp++
            }
        }
        foreach ($file in $userDataFiles) {
            $sourcePath = Join-Path $installDir $file
            if (Test-Path $sourcePath) {
                Copy-Item -Path $sourcePath -Destination (Join-Path $backupPath $file) -Force
                $backedUp++
            }
        }
        Write-Host "        Backed up $backedUp items" -ForegroundColor DarkGray
    } else {
        Write-Host "  [2/4] Skipping user data backup" -ForegroundColor DarkGray
    }

    # ══════════════════════════════════════════════════════════════
    # REMOVE FILES
    # ══════════════════════════════════════════════════════════════
    Write-Host "  [3/4] Removing files..." -ForegroundColor Yellow

    # Remove installation folder
    if (Test-Path $installDir) {
        try {
            Remove-Item -Path $installDir -Recurse -Force -ErrorAction Stop
            Write-Host "        ✓ Installation folder removed" -ForegroundColor DarkGray
        } catch {
            Write-Host "        ⚠ Could not remove some files (may be in use)" -ForegroundColor Yellow
        }
    }

    # Remove Desktop shortcut
    if (Test-Path $desktopShortcut) {
        Remove-Item -Path $desktopShortcut -Force -ErrorAction SilentlyContinue
        Write-Host "        ✓ Desktop shortcut removed" -ForegroundColor DarkGray
    }

    # Remove Start Menu folder
    if (Test-Path $startMenuFolder) {
        Remove-Item -Path $startMenuFolder -Recurse -Force -ErrorAction SilentlyContinue
        Write-Host "        ✓ Start Menu folder removed" -ForegroundColor DarkGray
    }

    # ══════════════════════════════════════════════════════════════
    # RESTORE USER DATA (if backed up)
    # ══════════════════════════════════════════════════════════════
    if ($KeepUserData -and $backupPath -and (Test-Path $backupPath)) {
        Write-Host "  [4/4] Saving user data..." -ForegroundColor Yellow

        $userDataSavePath = Join-Path ([Environment]::GetFolderPath("MyDocuments")) "geetRPCS_Backup"

        if (Test-Path $userDataSavePath) {
            Remove-Item -Path $userDataSavePath -Recurse -Force -ErrorAction SilentlyContinue
        }

        Copy-Item -Path $backupPath -Destination $userDataSavePath -Recurse -Force
        Remove-Item -Path $backupPath -Recurse -Force -ErrorAction SilentlyContinue

        Write-Host "        Saved to: $userDataSavePath" -ForegroundColor DarkGray
    } else {
        Write-Host "  [4/4] Cleanup complete" -ForegroundColor DarkGray
    }

    # ══════════════════════════════════════════════════════════════
    # DONE
    # ══════════════════════════════════════════════════════════════
    Write-Host ""
    Write-Host "  ╔═══════════════════════════════════════════╗" -ForegroundColor Green
    Write-Host "  ║    ✅ geetRPCS uninstalled successfully   ║" -ForegroundColor Green
    Write-Host "  ╚═══════════════════════════════════════════╝" -ForegroundColor Green
    Write-Host ""

    if ($KeepUserData) {
        Write-Host "  📁 User data saved to:" -ForegroundColor Cyan
        Write-Host "     $userDataSavePath" -ForegroundColor White
        Write-Host ""
        Write-Host "  You can restore this data when reinstalling." -ForegroundColor DarkGray
    }

    Write-Host ""
    Write-Host "  Thank you for using geetRPCS! 👋" -ForegroundColor Magenta
    Write-Host ""
}

# Auto-run
Uninstall-GeetRPCS
