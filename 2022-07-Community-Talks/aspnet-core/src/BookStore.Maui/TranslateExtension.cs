using BookStore.Maui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Maui
{
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {
        public string Text { get; set; } = string.Empty;

        public string? StringFormat { get; set; }


        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var localizationManager = serviceProvider.GetRequiredService<IRootObjectProvider>()
                .RootObject.As<BindableObject>()
                .BindingContext.As<BookStoreViewModelBase>()
                .L;

            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = localizationManager,
                StringFormat = StringFormat
            };
            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
