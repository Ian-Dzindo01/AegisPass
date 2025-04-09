using AegisPass.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace AegisPass.Views;

public sealed partial class LoginPage : Page
{
    private readonly AuthService _auth = new();

    public LoginPage()
    {
        this.InitializeComponent();
    }

    private void Login_Click(object sender, RoutedEventArgs e)
    {
        var email = EmailBox.Text;
        var password = PasswordBox.Password;

        if (_auth.Login(email, password))
        {
            ResultText.Text = "Login successful!";
            ResultText.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Green);
        }
        else
        {
            ResultText.Text = "Invalid email or password.";
            ResultText.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Red);
        }
    }
}
