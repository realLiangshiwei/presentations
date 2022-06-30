using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookStore.Localization;
using Volo.Abp.DependencyInjection;

namespace BookStore.Maui
{
    public class LocalizationManager : INotifyPropertyChanged, ISingletonDependency
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CultureInfo _currentCulture;
        private IStringLocalizer _localizer;

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                _currentCulture = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }

        public LocalizationManager(IServiceProvider serviceProvider)
        {
            _localizer = serviceProvider.GetRequiredService<IStringLocalizerFactory>().Create(typeof(BookStoreResource));
            _currentCulture = CultureInfo.CurrentCulture;
        }

        public LocalizedString this[string resourceKey] => GetValue(resourceKey);

        public LocalizedString GetValue(string resourceKey)
        {
            CultureInfo.CurrentCulture = CurrentCulture;
            CultureInfo.CurrentUICulture = CurrentCulture;

            return _localizer[resourceKey];
        }
    }
}
