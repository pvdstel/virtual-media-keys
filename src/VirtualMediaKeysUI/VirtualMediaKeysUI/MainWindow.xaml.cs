using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using VirtualMediaKeysUI.Native;
using VirtualMediaKeysUI.Util;

namespace VirtualMediaKeysUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string AccentColorKey = "AccentColor";
        private const string ForegroundColorKey = "ForegroundColor";

        private static Brush LightAccentForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        private static Brush DarkAccentForegroundColor = Brushes.White;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the accent color to the system color.
        /// </summary>
        private void SetColor()
        {
            var color = DWM.GetDwmColor();
            bool isBright = ColorUtil.DwmBrightness(color) > 128;
            Resources[AccentColorKey] = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
            Resources[ForegroundColorKey] = isBright ? LightAccentForegroundColor : DarkAccentForegroundColor;
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle).AddHook(WndProc);
            SetColor();


            
            // Set up custom window flags
            WindowManagement.SetWindowLongPtr64(
                new System.Runtime.InteropServices.HandleRef(null, handle),
                WindowManagement.GWL_STYLE,
                new IntPtr(WindowManagement.WS_VISIBLE | WindowManagement.WS_SIZEBOX)
            );
            WindowManagement.SetWindowLongPtr64(
                new System.Runtime.InteropServices.HandleRef(null, handle),
                WindowManagement.GWL_EXSTYLE,
                new IntPtr(WindowManagement.WS_EX_NOACTIVATE)
            );
        }

        /// <summary>
        /// Handles window messages.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == DWM.WM_DWMCOLORIZATIONCOLORCHANGED)
            {
                SetColor();
            }

            return IntPtr.Zero;
        }

        private void Caption_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
