using BlazorDay.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlazorDay.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BlazorDayController : AbpControllerBase
{
    protected BlazorDayController()
    {
        LocalizationResource = typeof(BlazorDayResource);
    }
}
