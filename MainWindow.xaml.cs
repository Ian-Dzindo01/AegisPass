using AegisPass.Views;
using Microsoft.UI.Xaml;

namespace AegisPass
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(LoginPage));
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(LoginPage));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(RegisterPage));
        }
    }
}
