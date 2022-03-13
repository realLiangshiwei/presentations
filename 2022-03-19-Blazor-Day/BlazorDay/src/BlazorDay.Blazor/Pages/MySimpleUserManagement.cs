// using System;
// using System.Threading.Tasks;
// using AntDesign;
// using Lsw.Abp.AspnetCore.Components.Web.AntDesignTheme.PageToolbars;
// using Lsw.Abp.IdentityManagement.Blazor.AntDesignUI.Pages;
// using Volo.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
// using Volo.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
// using Volo.Abp.DependencyInjection;
// using Volo.Abp.Identity;
//
// namespace BlazorDay.Blazor.Pages;
//
// [ExposeServices(typeof(UserManagement))]
// public class MySimpleUserManagement : UserManagement
// {
//     protected override async ValueTask SetEntityActionsAsync()
//     {
//          await base.SetEntityActionsAsync();
//          EntityActions
//              .Get<UserManagement>().Add(new EntityAction
//              {
//                  Text = "Send activation email",
//                  Clicked = async (data) =>
//                  {
//                      await Message.Success("An email has been sent.");
//                  }
//              });
//     }
//
//     protected override ValueTask SetToolbarItemsAsync()
//     {
//         Toolbar.AddButton("Check Me",
//             async () =>
//             {
//                 await Message.Success("checked message!");
//             },
//             IconType.Outline.Plus,
//             requiredPolicyName: CreatePolicyName);
//         
//         return base.SetToolbarItemsAsync();
//     }
//
//     protected override async ValueTask SetTableColumnsAsync()
//     {
//         await base.SetTableColumnsAsync();
//         TableColumns.Get<UserManagement>().Insert(3,new TableColumn()
//         {
//             Title = "IsActive",
//             ValueConverter = data => ((IdentityUserDto)data).EmailConfirmed ? "是" : "否"
//         });
//     }
// }
