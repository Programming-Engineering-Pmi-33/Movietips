namespace WpfMediaPlayer
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using Microsoft.Win32;
    using System.Windows.Controls.Primitives;

    public partial class MainWindow : Window
    {
        private bool isPlaying = false;

        public MainWindow()
        {
            this.InitializeComponent();
            this.ChangeIsPlaying(false);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan mom = new TimeSpan(0, 0, 5);
            TimeSpan mom2 = new TimeSpan(0, 0, 9);

            if (mediaElement.Source != null)
            {
                if (mediaElement.Position >= mom && mediaElement.Position <= mom2)
                {
                    btnTip.Visibility = Visibility.Visible;
                }
                if (mediaElement.Position > mom2)
                {
                    btnTip.Visibility = Visibility.Hidden;
                }
            }
        }

        private void btnTip_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
            moviePopUp.IsOpen = true;
            this.ChangeIsPlaying(!this.isPlaying);
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            moviePopUp.IsOpen = false;
            this.mediaElement.Play();
            this.ChangeIsPlaying(!this.isPlaying);
        }

        private void addComment_OnClick(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source != null)
            {
                mediaElement.Pause();
                addPopUp.IsOpen = true;
            }
            else
            {
                MessageBox.Show("No movie is running...", "Alert", MessageBoxButton.OK);
            }
        }

        private void pushComment_OnClick(object sender, RoutedEventArgs e)
        {
            // додати код для пушу комента в бд
            addPopUp.IsOpen = false;
            this.mediaElement.Play();
            this.ChangeIsPlaying(!this.isPlaying);
        }

        private void cancelComment_OnClick(object sender, RoutedEventArgs e)
        {
            addPopUp.IsOpen = false;
            this.mediaElement.Play();
            this.ChangeIsPlaying(!this.isPlaying);
        }

        private void PlayPause_OnClick(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source != null)
            {
                this.ChangeIsPlaying(!this.isPlaying);
            }
            else
            {
                MessageBox.Show("No movie is running...", "Alert", MessageBoxButton.OK);
            }
        }
        private void SetMediaSource(string file)
        {
            this.mediaElement.Source = new Uri(file);
        }

        private void Stop_OnClick(object sender, RoutedEventArgs e)
        {
            this.OnMediaEnded();
        }

        private void MediaElement_OnMediaEnded(object sender, RoutedEventArgs e)
        {
            this.OnMediaEnded();
        }

        private void MediaElement_OnMediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            this.OnMediaEnded();
        }

        private void OnMediaEnded()
        {
            this.mediaElement.Stop();
            this.ChangeIsPlaying(false);
        }

        private void ChangeIsPlaying(bool isPlaying)
        {
            this.isPlaying = isPlaying;

            if (this.isPlaying)
            {
                this.playPause.ChangeToPlayingState();
                this.mediaElement.Play();
            }
            else
            {
                this.playPause.ChangeToPauseState();
                this.mediaElement.Pause();
            }
        }

        private void VolumeSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.mediaElement.Volume = this.volumeSlider.Value;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            string file = this.OpenFile();
            if (file == null)
            {
                return;
            }

            this.SetMediaSource(file);
        }

        private string OpenFile()
        {
            string filter = "Video (*.avi, *.mkv, *.mp4, *.flv)|*.avi;*.mkv;*.mp4;*.flv|Audio(*.ogg, *.mp3, *.wav)|*.ogg;*.mp3;*.wav;|All Files(*.*)|*.*";
            var openDialog = new OpenFileDialog {Multiselect = false, CheckFileExists = true, CheckPathExists = true, Title = "Select video file", AddExtension = true, Filter = filter};
            if (openDialog.ShowDialog(this) == true)
            {
                return openDialog.FileName;
            }
            return null;
        }

        private void About_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this, "MovieTips inc. copyright 2020, All rights reserved");
        }
    }
}
