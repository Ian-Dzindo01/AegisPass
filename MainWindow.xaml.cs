using Microsoft.UI.Xaml;

namespace AegisPass
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            MessageText.Text = "You clicked the button!";
        }
    }
}
