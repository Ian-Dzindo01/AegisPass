using AegisPass.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;

namespace AegisPass.Views;

public sealed partial class RegisterPage : Page
{
    private readonly AuthService _auth = new();

    public RegisterPage()
    {
        this.InitializeComponent();
    }

    private void Register_Click(object sender, RoutedEventArgs e)
    {
        var email = EmailBox.Text;
        var password = PasswordBox.Password;

        if (_auth.Register(email, password))
        {
            ResultText.Text = "Registration successful!";
            ResultText.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Green);
        }
        else
        {
            ResultText.Text = "Email already exists.";
            ResultText.Foreground = new SolidColorBrush(Microsoft.UI.Colors.Red);
        }
    }
}
