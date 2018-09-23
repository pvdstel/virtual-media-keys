using System.Runtime.InteropServices;

namespace VirtualMediaKeysUI.Native
{
    internal static class DWM
    {
        public const int WM_DWMCOLORIZATIONCOLORCHANGED = 800;

        [DllImport("dwmapi.dll", PreserveSig = false)]
        private static extern void DwmGetColorizationColor(out uint ColorizationColor, [MarshalAs(UnmanagedType.Bool)]out bool ColorizationOpaqueBlend);

        public struct DwmColor
        {
            public DwmColor(byte a, byte r, byte g, byte b)
            {
                A = a;
                R = r;
                G = g;
                B = b;
            }

            public byte A { get; }
            public byte R { get; }
            public byte G { get; }
            public byte B { get; }
        }

        public static DwmColor GetDwmColor()
        {
            DwmGetColorizationColor(out uint color, out bool isOpaque);
            return new DwmColor(
                (byte)(color >> 24 & byte.MaxValue),
                (byte)(color >> 16 & byte.MaxValue),
                (byte)(color >> 8 & byte.MaxValue),
                (byte)(color & byte.MaxValue)
            );
        }
    }
}
