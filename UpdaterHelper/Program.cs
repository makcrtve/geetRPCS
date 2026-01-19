/**
 * geetRPCS - Updater Helper
 * Helper utility for performing automated updates
 */
/*
 * Copyright (c) 2026 makcrtve
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 */

#nullable enable
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace geetRPCS.Updater
{
    class Program
    {
        private const int MAX_WAIT_SECONDS = 30;
        private const int RETRY_DELAY_MS = 500;
        private const int MAX_RETRIES = 3;

        static int Main(string[] args)
        {
            Console.Title = "geetRPCS Updater";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("  ╔═══════════════════════════════════════════╗");
            Console.WriteLine("  ║         geetRPCS Updater Helper           ║");
            Console.WriteLine("  ╚═══════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();

            try
            {
                // Parse arguments
                string? sourcePath = null;
                string? targetPath = null;
                string? exeName = null;

                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i].ToLower())
                    {
                        case "--source":
                            if (i + 1 < args.Length) sourcePath = args[++i];
                            break;
                        case "--target":
                            if (i + 1 < args.Length) targetPath = args[++i];
                            break;
                        case "--exe":
                            if (i + 1 < args.Length) exeName = args[++i];
                            break;
                    }
                }

                // Validate arguments
                if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(targetPath) || string.IsNullOrEmpty(exeName))
                {
                    PrintError("Missing required arguments!");
                    Console.WriteLine();
                    Console.WriteLine("Usage: Updater.exe --source <path> --target <path> --exe <name>");
                    Console.WriteLine();
                    Console.WriteLine("Arguments:");
                    Console.WriteLine("  --source  Path to extracted update files");
                    Console.WriteLine("  --target  Path to geetRPCS installation");
                    Console.WriteLine("  --exe     Name of executable (geetRPCS.exe)");
                    Console.WriteLine();
                    PressAnyKey();
                    return 1;
                }

                PrintInfo($"Source: {sourcePath}");
                PrintInfo($"Target: {targetPath}");
                PrintInfo($"Executable: {exeName}");
                Console.WriteLine();

                // Validate paths
                if (!Directory.Exists(sourcePath))
                {
                    PrintError($"Source folder not found: {sourcePath}");
                    PressAnyKey();
                    return 1;
                }

                // Step 1: Wait for geetRPCS to close
                PrintStep("1/4", "Waiting for geetRPCS to close...");
                if (!WaitForProcessToClose("geetRPCS", MAX_WAIT_SECONDS))
                {
                    PrintError("geetRPCS is still running. Please close it manually.");
                    PressAnyKey();
                    return 1;
                }
                PrintSuccess("geetRPCS closed.");
                Console.WriteLine();

                // Step 2: Remove old files
                PrintStep("2/4", "Removing old files...");
                if (!RemoveOldFiles(targetPath))
                {
                    PrintError("Failed to remove some old files. Update may be incomplete.");
                    // Continue anyway - try best effort
                }
                PrintSuccess("Old files removed.");
                Console.WriteLine();

                // Step 3: Copy new files
                PrintStep("3/4", "Installing new files...");
                if (!CopyNewFiles(sourcePath, targetPath))
                {
                    PrintError("Failed to copy new files!");
                    PressAnyKey();
                    return 1;
                }
                PrintSuccess("New files installed.");
                Console.WriteLine();

                // Step 4: Clean up and launch
                PrintStep("4/4", "Cleaning up and launching geetRPCS...");

                // Try to clean up temp folder
                try
                {
                    string? tempFolder = Path.GetDirectoryName(sourcePath);
                    if (tempFolder != null && tempFolder.Contains("geetRPCS_update"))
                    {
                        Directory.Delete(tempFolder, true);
                        PrintInfo("Temp files cleaned up.");
                    }
                }
                catch { /* Ignore cleanup errors */ }

                // Launch geetRPCS
                string exePath = Path.Combine(targetPath, exeName);
                if (File.Exists(exePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        WorkingDirectory = targetPath,
                        UseShellExecute = true
                    });
                    PrintSuccess("geetRPCS launched successfully!");
                }
                else
                {
                    PrintError($"Executable not found: {exePath}");
                    PrintInfo("Please launch geetRPCS manually.");
                    PressAnyKey();
                    return 1;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("  ╔═══════════════════════════════════════════╗");
                Console.WriteLine("  ║      Update completed successfully!       ║");
                Console.WriteLine("  ╚═══════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();

                // Wait for user to read output
                PressAnyKey();

                return 0;
            }
            catch (Exception ex)
            {
                PrintError($"Unexpected error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                PressAnyKey();
                return 1;
            }
        }

        private static bool WaitForProcessToClose(string processName, int maxSeconds)
        {
            for (int i = 0; i < maxSeconds; i++)
            {
                var processes = Process.GetProcessesByName(processName);
                if (processes.Length == 0)
                {
                    return true;
                }

                foreach (var p in processes)
                {
                    p.Dispose();
                }

                Console.Write($"\r  Waiting... {maxSeconds - i}s remaining  ");
                Thread.Sleep(1000);
            }

            Console.WriteLine();
            return false;
        }

        private static bool RemoveOldFiles(string targetPath)
        {
            if (!Directory.Exists(targetPath))
            {
                return true; // Nothing to remove
            }

            bool success = true;

            // Remove files
            foreach (var file in Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories))
            {
                // Skip the updater itself
                if (Path.GetFileName(file).Equals("Updater.exe", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                for (int retry = 0; retry < MAX_RETRIES; retry++)
                {
                    try
                    {
                        File.Delete(file);
                        break;
                    }
                    catch
                    {
                        if (retry == MAX_RETRIES - 1)
                        {
                            PrintWarning($"Could not delete: {Path.GetFileName(file)}");
                            success = false;
                        }
                        Thread.Sleep(RETRY_DELAY_MS);
                    }
                }
            }

            // Remove empty directories (bottom-up)
            try
            {
                foreach (var dir in Directory.GetDirectories(targetPath, "*", SearchOption.AllDirectories)
                    .OrderByDescending(d => d.Length))
                {
                    if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                    {
                        Directory.Delete(dir);
                    }
                }
            }
            catch { /* Ignore directory cleanup errors */ }

            return success;
        }

        private static bool CopyNewFiles(string sourcePath, string targetPath)
        {
            try
            {
                // Create target if it doesn't exist
                Directory.CreateDirectory(targetPath);

                // Copy all files
                foreach (var file in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
                {
                    string relativePath = Path.GetRelativePath(sourcePath, file);
                    string destPath = Path.Combine(targetPath, relativePath);

                    // Create directory if needed
                    string? destDir = Path.GetDirectoryName(destPath);
                    if (destDir != null && !Directory.Exists(destDir))
                    {
                        Directory.CreateDirectory(destDir);
                    }

                    // Copy with retry
                    bool copied = false;
                    for (int retry = 0; retry < MAX_RETRIES && !copied; retry++)
                    {
                        try
                        {
                            File.Copy(file, destPath, true);
                            copied = true;
                        }
                        catch
                        {
                            Thread.Sleep(RETRY_DELAY_MS);
                        }
                    }

                    if (!copied)
                    {
                        PrintError($"Failed to copy: {relativePath}");
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                PrintError($"Copy error: {ex.Message}");
                return false;
            }
        }

        // --- Console Helpers ---

        private static void PrintStep(string step, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"  [{step}] ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        private static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"  {message}");
            Console.ResetColor();
        }

        private static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  {message}");
            Console.ResetColor();
        }

        private static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"  ⚠️ {message}");
            Console.ResetColor();
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ❌ {message}");
            Console.ResetColor();
        }

        private static void PressAnyKey()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
