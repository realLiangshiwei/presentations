using System;
using System.Collections.Generic;
using System.Text;
using BlazorDay.Localization;
using Volo.Abp.Application.Services;

namespace BlazorDay;

/* Inherit your application services from this class.
 */
public abstract class BlazorDayAppService : ApplicationService
{
    protected BlazorDayAppService()
    {
        LocalizationResource = typeof(BlazorDayResource);
    }
}
