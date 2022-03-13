using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlazorDay.Data;

/* This is used if database provider does't define
 * IBlazorDayDbSchemaMigrator implementation.
 */
public class NullBlazorDayDbSchemaMigrator : IBlazorDayDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
