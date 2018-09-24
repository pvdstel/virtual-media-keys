using System.Windows;
using System.Windows.Input;
using VirtualMediaKeysUI.Controls;
using VirtualMediaKeysUI.Native;

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

        private void MediaButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            const int TitlebarVerticalInfluence = 28;
            if (ShowTitlebar)
            {
                ShowTitlebar = false;
                Height -= TitlebarVerticalInfluence;
                Top += TitlebarVerticalInfluence;
            }
            else
            {
                ShowTitlebar = true;
                Top -= TitlebarVerticalInfluence;
                Height += TitlebarVerticalInfluence;
            }
        }

        private void VolumeButton_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TrackAccentColor = !TrackAccentColor;
        }
    }
}
