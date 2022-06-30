using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp.Threading;

namespace BookStore.Maui
{
    internal class MauiCurrentPrincipalAccessor : CurrentPrincipalAccessorBase, ITransientDependency
    {
        protected override ClaimsPrincipal GetClaimsPrincipal()
        {
            var token = AsyncHelper.RunSync(()=> SecureStorage.GetAsync("access_token"));

            if (token.IsNullOrWhiteSpace())
            {
                return new ClaimsPrincipal();
            }

            var jwtToken = (new JwtSecurityTokenHandler()).ReadJwtToken(token);

            return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
        }
    }
}
