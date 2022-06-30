using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Localization;
using BookStore.Web;
using IdentityModel;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Options;
using Volo.Abp.Account.Localization;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;

namespace BookStore.Maui
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(BookStoreHttpApiClientModule))]
    public class MauiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
#if DEBUG
            PreConfigure<AbpHttpClientBuilderOptions>(options =>
            {
                options.ProxyClientBuildActions.Add((_, clientBuilder) =>
                {
                    clientBuilder.ConfigurePrimaryHttpMessageHandler(GetInsecureHandler);
                });
            });
#endif
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<BookStoreResource>()
                    .AddBaseTypes(typeof(IdentityResource))
                    .AddBaseTypes(typeof(AccountResource));
            });

            var configuration = context.Services.GetConfiguration();
            Configure<OidcClientOptions>(configuration.GetSection("Oidc:Options"));

            context.Services.AddTransient<OidcClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<OidcClientOptions>>().Value;
                options.Browser = sp.GetRequiredService<MauiAuthenticationBrowser>();

#if DEBUG
                options.BackchannelHandler = GetInsecureHandler();
#endif

                return new OidcClient(options);
            });

            MapClaimTypes();

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private static HttpClientHandler GetInsecureHandler()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                {
                    return true;
                }

                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        private static void MapClaimTypes()
        {
            AbpClaimTypes.UserName = JwtClaimTypes.PreferredUserName;
            AbpClaimTypes.Name = JwtClaimTypes.GivenName;
            AbpClaimTypes.SurName = JwtClaimTypes.FamilyName;
            AbpClaimTypes.UserId = JwtClaimTypes.Subject;
            AbpClaimTypes.Role = JwtClaimTypes.Role;
            AbpClaimTypes.Email = JwtClaimTypes.Email;
        }
    }
}
