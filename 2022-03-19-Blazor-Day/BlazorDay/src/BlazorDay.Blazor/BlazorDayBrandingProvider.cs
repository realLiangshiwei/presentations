using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlazorDay.Blazor;

[Dependency(ReplaceServices = true)]
public class BlazorDayBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BlazorDay";
}
