using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace TodoApp.Web;

public class BootswatchStyleContributor : BundleContributor
{
    public override void ConfigureBundle(BundleConfigurationContext context)
    {
        var theme = "Lux";

        context.Files.ReplaceOne(
            "/libs/bootstrap/css/bootstrap.css",
            $"/libs/bootswatch/{theme}/bootstrap.css"
        );
    }
}
