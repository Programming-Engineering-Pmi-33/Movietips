using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using FileStore;

namespace mainInterface
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void help_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To start watching a movie — press Open, then select a film to watch. Or select a movie from MovieTips movie base.", "Help", MessageBoxButton.OK);
        }

        private void SetMediaSource(string file)
        {
            //this.mediaElement.Source = new Uri(file);
        }

        private string OpenFile()
        {
            string filter = "Video (*.avi, *.mkv, *.mp4, *.flv)|*.avi;*.mkv;*.mp4;*.flv|Audio(*.ogg, *.mp3, *.wav)|*.ogg;*.mp3;*.wav;|All Files(*.*)|*.*";
            var openDialog = new OpenFileDialog { Multiselect = false, CheckFileExists = true, CheckPathExists = true, Title = "Select video file", AddExtension = true, Filter = filter };
            if (openDialog.ShowDialog(this) == true)
            {
                return openDialog.FileName;
            }
            return null;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            string file = this.OpenFile();
            if (file == null)
            {
                return;
            }
            WpfMediaPlayer.PlayerWindow player = new WpfMediaPlayer.PlayerWindow(file);
            player.Show();
            
        }
    }
}
