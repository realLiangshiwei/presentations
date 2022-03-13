using Volo.Abp.Settings;

namespace BlazorDay.Settings;

public class BlazorDaySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BlazorDaySettings.MySetting1));
    }
}
