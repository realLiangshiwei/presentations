using BookStore.Localization;
using IdentityModel.Client;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace BookStore.Maui
{
    public partial class MainPage : ContentPage, ITransientDependency
    {
        private readonly OidcClient _oidcClient;
        private readonly ICurrentUser _currentUser;

        public MainPage(
            OidcClient oidcClient, 
            ICurrentUser currentUser)
        {
            _oidcClient = oidcClient;
            _currentUser = currentUser;
            InitializeComponent();

            LoginBtn.Text = _currentUser.IsAuthenticated ? "注销" : "登录";
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!_currentUser.IsAuthenticated)
            {
                string token;
                if (DeviceInfo.Platform == DevicePlatform.WinUI)
                {
                    token = await SignWithPasswordFlow();
                }
                else
                {
                    var loginResult = await _oidcClient.LoginAsync();
                    if (loginResult.IsError)
                    {
                        await DisplayAlert("Error", loginResult.Error, "Close");
                        return;
                    }

                    token = loginResult.AccessToken;
                }

                await SecureStorage.SetAsync("access_token", token);
                LoginBtn.Text = "注销";
            }
            else
            {
                if (DeviceInfo.Platform != DevicePlatform.WinUI)
                {
                    await _oidcClient.LogoutAsync();
                }
                
                LoginBtn.Text = "登录";
                SecureStorage.Remove("access_token");
            }
        }

        private async Task<string> SignWithPasswordFlow()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest()
            {
                Address = "https://localhost:44374/connect/token",
                ClientId = "BookStore_Maui",
                ClientSecret = "1q2w3e*",
                UserName = "admin",
                Password = "1q2w3E*",
                Scope = "offline_access BookStore"
            });

            return response.AccessToken;
        }
    }
}