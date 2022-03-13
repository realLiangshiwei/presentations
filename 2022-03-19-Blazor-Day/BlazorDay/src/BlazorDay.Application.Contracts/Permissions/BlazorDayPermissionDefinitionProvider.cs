using BlazorDay.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlazorDay.Permissions;

public class BlazorDayPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BlazorDayPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BlazorDayPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BlazorDayResource>(name);
    }
}
