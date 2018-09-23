using System;
using System.Runtime.InteropServices;

namespace VirtualMediaKeysUI.Native
{
    internal static class WindowManagement
    {
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;

        public const int WS_VISIBLE = 0x10000000;
        public const int WS_SIZEBOX = 0x00040000;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_APPWINDOW = 0x00040000;

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);
    }
}
