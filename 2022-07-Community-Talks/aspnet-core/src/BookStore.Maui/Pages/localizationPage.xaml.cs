using BookStore.Maui.ViewModels;
using Volo.Abp.DependencyInjection;

namespace BookStore.Maui.Pages;

public partial class LocalizationPage : ContentPage, ITransientDependency
{
    public LocalizationPage(LocalizationViewModel vm)
    {
        BindingContext = vm;
		InitializeComponent();
	}
}