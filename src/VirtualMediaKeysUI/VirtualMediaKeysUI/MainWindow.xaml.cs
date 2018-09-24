using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using VirtualMediaKeysUI.Controls;
using VirtualMediaKeysUI.Native;
using VirtualMediaKeysUI.Util;

namespace VirtualMediaKeysUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : OverlayWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.MEDIA_PREV_TRACK);
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.MEDIA_PLAY_PAUSE);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.MEDIA_NEXT_TRACK);
        }

        private void VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.VOLUME_DOWN);
        }

        private void VolumeMute_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.VOLUME_MUTE);
        }

        private void VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            Input.SendKeyPress(Input.KeyCode.VOLUME_UP);
        }
    }
}
