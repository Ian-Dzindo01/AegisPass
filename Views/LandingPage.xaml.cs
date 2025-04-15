using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AegisPass.Views;

public sealed partial class LandingPage : Page
{
    public LandingPage()
    {
        this.InitializeComponent();
    }

    private void OpenVault_Click(object sender, RoutedEventArgs e)
    {
        ContentDialog dialog = new()
        {
            Title = "Vault Opening",
            Content = "This is where you'd navigate to the user's vault.",
            CloseButtonText = "OK",
            XamlRoot = this.XamlRoot
        };
        _ = dialog.ShowAsync();
    }
}
