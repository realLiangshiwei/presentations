using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.Authentication;

namespace BookStore.Maui
{
    internal class MauiRemoteServiceHttpClientAuthenticator : IRemoteServiceHttpClientAuthenticator, ITransientDependency
    {
        public async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            var accessToken =await SecureStorage.GetAsync("access_token");

            if (!accessToken.IsNullOrEmpty())
            {
                context.Request.SetBearerToken(accessToken);
            }
        }
    }
}
