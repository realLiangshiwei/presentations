using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using BookStore.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BookStore.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits BookStore.Web.Pages.BookStorePage
     */
    public abstract class BookStorePage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<BookStoreResource> L { get; set; }
    }
}
