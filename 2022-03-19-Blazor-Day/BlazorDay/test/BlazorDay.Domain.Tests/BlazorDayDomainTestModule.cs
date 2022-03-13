using BlazorDay.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlazorDay;

[DependsOn(
    typeof(BlazorDayEntityFrameworkCoreTestModule)
    )]
public class BlazorDayDomainTestModule : AbpModule
{

}
