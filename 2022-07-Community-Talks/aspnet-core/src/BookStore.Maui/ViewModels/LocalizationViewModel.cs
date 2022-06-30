using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;
using System.Windows.Input;

namespace BookStore.Maui.ViewModels
{
    public class LocalizationViewModel : BookStoreViewModelBase, ITransientDependency
    {

        private readonly AbpLocalizationOptions _localizationOptions;

        public ICommand ChangeLanguageCommand { get; }

        public LocalizationViewModel(IOptions<AbpLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions.Value;
            ChangeLanguageCommand = new Command(ChangeLanguageAsync);
        }

        private async void ChangeLanguageAsync()
        {
            var selectedLanguage = await Shell.Current.CurrentPage.DisplayActionSheet(null, null, null,
                _localizationOptions.Languages.Select(x => x.DisplayName).ToArray());

            if (selectedLanguage.IsNullOrWhiteSpace())
            {
                return;
            }

            var culture = _localizationOptions.Languages.FirstOrDefault(x => x.DisplayName == selectedLanguage);
            if (culture == null)
            {
                return;
            }

            L.CurrentCulture = new CultureInfo(culture.CultureName);
        }
    }
}
