using System;
using static VirtualMediaKeysUI.Native.DWM;

namespace VirtualMediaKeysUI.Util
{
    internal static class ColorUtil
    {
        public static double DwmBrightness(DwmColor c)
        {
            return Math.Sqrt(
                c.R * c.R * .241 +
                c.G * c.G * .691 +
                c.B * c.B * .068
            );
        }
    }
}
