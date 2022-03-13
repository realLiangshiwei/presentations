using BlazorDay.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BlazorDay.Blazor;

public abstract class BlazorDayComponentBase : AbpComponentBase
{
    protected BlazorDayComponentBase()
    {
        LocalizationResource = typeof(BlazorDayResource);
    }
}
