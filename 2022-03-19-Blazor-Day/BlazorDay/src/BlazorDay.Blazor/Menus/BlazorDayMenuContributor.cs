using System.Threading.Tasks;
using BlazorDay.Localization;
using BlazorDay.MultiTenancy;
using Volo.Abp.UI.Navigation;

//using Volo.Abp.Identity.Blazor;
//using Volo.Abp.SettingManagement.Blazor.Menus;
//using Volo.Abp.TenantManagement.Blazor.Navigation;

using AntDesign;
using Lsw.Abp.IdentityManagement.Blazor.AntDesignUI;
using Lsw.Abp.SettingManagement.Blazor.AntDesignUI;
using Lsw.Abp.TenantManagement.Blazor.AntDesignUI;


namespace BlazorDay.Blazor.Menus;

public class BlazorDayMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BlazorDayResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BlazorDayMenus.Home,
                l["Menu:Home"],
                "/",
                icon: IconType.Outline.Home,//  "fas fa-home", // 
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
