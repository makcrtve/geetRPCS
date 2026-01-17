/**
 * geetRPCS - Memory Helper
 * Optimization utilities for minimizing RAM usage
 */

using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace geetRPCS.Utils
{
    internal static class MemoryHelper
    {
        [DllImport("psapi.dll")]
        private static extern bool EmptyWorkingSet(IntPtr hProcess);
        public static void TrimMemory()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    GC.Collect(2, GCCollectionMode.Forced, true);
                    GC.WaitForPendingFinalizers();
                }
                using (var currentProcess = Process.GetCurrentProcess())
                {
                    EmptyWorkingSet(currentProcess.Handle);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrimMemory error: {ex.Message}");
            }
        }
    }
}
