using Android.App;
using Android.Content;
using Android.Content.PM;

namespace BookStore.Maui.Platforms.Android
{
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = CALLBACK_SCHEME)]
    public class BookStoreWebAuthenticatorCallbackActivity : WebAuthenticatorCallbackActivity
    {
        public const string CALLBACK_SCHEME = "bookstore";
    }
}
