/**
 * geetRPCS - P/Invoke Definitions
 * Win32 API declarations for system-level interactions
 */

namespace geetRPCS.Utils
{
    internal static partial class PInvoke
    {
        internal static class User32
        {
            public const int SW_HIDE = 0;
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            internal static extern bool ShowWindow(System.IntPtr hWnd, int nCmdShow);
            [System.Runtime.InteropServices.DllImport("kernel32.dll")]
            internal static extern System.IntPtr GetConsoleWindow();
        }
    }
}
