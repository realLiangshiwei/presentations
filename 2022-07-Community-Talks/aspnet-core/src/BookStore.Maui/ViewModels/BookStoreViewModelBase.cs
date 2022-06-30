using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace BookStore.Maui.ViewModels
{
    public abstract class BookStoreViewModelBase : BindableObject
    {
        public IAbpLazyServiceProvider LazyServiceProvider { get; set; }

        public LocalizationManager L => LazyServiceProvider.LazyGetRequiredService<LocalizationManager>();

    }
}
