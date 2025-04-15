using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Linq;
using System.Threading.Tasks;

public class B2CAuthenticationService
{
    private readonly IPublicClientApplication _pca;
    private readonly string[] _scopes = new[] { "openid", "offline_access" };

    public B2CAuthenticationService(IConfiguration config)
    {
        var b2c = config.GetSection("AzureAdB2C");

        _pca = PublicClientApplicationBuilder.Create(b2c["ClientId"])
            .WithB2CAuthority($"{b2c["Instance"]}/tfp/{b2c["Domain"]}/{b2c["SignUpSignInPolicyId"]}")
            .WithRedirectUri(b2c["CallbackPath"])
            .Build();
    }

    public async Task<AuthenticationResult?> SignInAsync()
    {
        try
        {
            var accounts = await _pca.GetAccountsAsync();
            return await _pca.AcquireTokenSilent(_scopes, accounts.FirstOrDefault())
                             .ExecuteAsync();
        }
        catch (MsalUiRequiredException)
        {
            return await _pca.AcquireTokenInteractive(_scopes)
                             .WithPrompt(Prompt.SelectAccount)
                             .ExecuteAsync();
        }
    }
}
