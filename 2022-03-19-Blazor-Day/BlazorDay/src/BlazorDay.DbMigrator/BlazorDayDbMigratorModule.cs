using BlazorDay.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace BlazorDay.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BlazorDayEntityFrameworkCoreModule),
    typeof(BlazorDayApplicationContractsModule)
    )]
public class BlazorDayDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
