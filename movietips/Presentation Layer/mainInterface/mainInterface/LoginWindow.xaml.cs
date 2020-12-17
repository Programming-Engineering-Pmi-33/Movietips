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

namespace registrationInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow objSecondWindow = new SecondWindow();
            this.Visibility = Visibility.Hidden;
            objSecondWindow.Show();
        }
    }
}
