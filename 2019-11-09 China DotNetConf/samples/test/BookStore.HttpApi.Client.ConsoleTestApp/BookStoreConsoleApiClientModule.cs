using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BookStore.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(BookStoreHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BookStoreConsoleApiClientModule : AbpModule
    {
        
    }
}
