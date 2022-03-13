using Volo.Abp.Modularity;

namespace BlazorDay;

[DependsOn(
    typeof(BlazorDayApplicationModule),
    typeof(BlazorDayDomainTestModule)
    )]
public class BlazorDayApplicationTestModule : AbpModule
{

}
