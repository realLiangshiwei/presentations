using IdentityModel.OidcClient.Browser;
using Volo.Abp.DependencyInjection;
using IBrowser = IdentityModel.OidcClient.Browser.IBrowser;

namespace BookStore.Web
{
    public class MauiAuthenticationBrowser : IBrowser, ITransientDependency
    {
        public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await WebAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
                {
                    Url = new Uri(options.StartUrl),
                    CallbackUrl = new Uri(options.EndUrl),
                    PrefersEphemeralWebBrowserSession = true
                });

                return new BrowserResult
                {
                    Response = ToRawIdentityUrl(options.EndUrl, result)
                };
            }
            catch (TaskCanceledException)
            {
                return new BrowserResult
                {
                    ResultType = BrowserResultType.UserCancel
                };
            }
            catch (Exception ex)
            {
                return new BrowserResult
                {
                    ResultType = BrowserResultType.UnknownError,
                    Error = ex.ToString()
                };
            }
        }

        private static string ToRawIdentityUrl(string redirectUrl, WebAuthenticatorResult result)
        {
            var parameters = result.Properties.Select(pair => $"{pair.Key}={pair.Value}");
            var values = string.Join("&", parameters);

            return $"{redirectUrl}#{values}";
        }
    }
}
