using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using VirtualMediaKeysUI.Native;
using VirtualMediaKeysUI.Util;

namespace VirtualMediaKeysUI.Controls
{
    /// <summary>
    /// A window that uses the color of the current accent.
    /// </summary>
    [TemplatePart(Name = PART_TitleDragArea, Type = typeof(UIElement))]
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    public class OverlayWindow : Window
    {
        private const string PART_TitleDragArea = "PART_TitleDragArea";
        private const string PART_CloseButton = "PART_CloseButton";

        public static DependencyProperty TrackAccentColorProperty = DependencyProperty.Register(nameof(TrackAccentColor), typeof(bool), typeof(OverlayWindow), new PropertyMetadata(true, (e, v) => ((OverlayWindow)e).UpdateColor()));

        private static Brush LightAccentForegroundColor = new SolidColorBrush(Color.FromRgb(51, 51, 51));
        private static Brush DarkAccentForegroundColor = Brushes.White;

        private UIElement titleDragArea;
        private Button closeButton;

        static OverlayWindow()
        {
            LightAccentForegroundColor.Freeze();
            DarkAccentForegroundColor.Freeze();

            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(OverlayWindow),
                new FrameworkPropertyMetadata(typeof(OverlayWindow))
            );
        }

        public bool TrackAccentColor
        {
            get => (bool)GetValue(TrackAccentColorProperty);
            set => SetValue(TrackAccentColorProperty, value);
        }

        /// <summary>
        /// Sets the accent color to the system color.
        /// </summary>
        protected void UpdateColor()
        {
            if (TrackAccentColor)
            {
                var color = DWM.GetDwmColor();
                bool isBright = ColorUtil.DwmBrightness(color) > 128;
                Resources[App.AccentColorKey] = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
                Resources[App.ForegroundColorKey] = isBright ? LightAccentForegroundColor : DarkAccentForegroundColor;
            }
            else
            {
                Resources[App.AccentColorKey] = App.Current.Resources[App.AccentColorKey];
                Resources[App.ForegroundColorKey] = App.Current.Resources[App.ForegroundColorKey];
            }
        }

        public override void OnApplyTemplate()
        {
            if (titleDragArea != null)
            {
                titleDragArea.MouseLeftButtonDown -= titleDragArea_MouseLeftButtonDown;
            }
            titleDragArea = GetTemplateChild(PART_TitleDragArea) as UIElement;
            if (titleDragArea != null)
            {
                titleDragArea.MouseLeftButtonDown += titleDragArea_MouseLeftButtonDown;
            }

            if (closeButton != null)
            {
                closeButton.Click -= CloseButton_Click;
            }
            closeButton = GetTemplateChild(PART_CloseButton) as Button;
            if (closeButton != null)
            {
                closeButton.Click += CloseButton_Click;
            }

            base.OnApplyTemplate();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle).AddHook(WndProc);
            UpdateColor();

            // Set up custom window flags
            WindowManagement.SetWindowLongPtr(
                new System.Runtime.InteropServices.HandleRef(null, handle),
                WindowManagement.GWL_STYLE,
                new IntPtr(WindowManagement.WS_VISIBLE | WindowManagement.WS_SIZEBOX)
            );
            WindowManagement.SetWindowLongPtr(
                new System.Runtime.InteropServices.HandleRef(null, handle),
                WindowManagement.GWL_EXSTYLE,
                new IntPtr(WindowManagement.WS_EX_NOACTIVATE)
            );

            base.OnSourceInitialized(e);
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
                UpdateColor();
            }

            return IntPtr.Zero;
        }

        private void titleDragArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
