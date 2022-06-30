using BookStore.Maui.ViewModels;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;

namespace BookStore.Maui.Pages;

public partial class UsersPage : ContentPage , ITransientDependency
{
    private readonly ICurrentUser _currentUser;

	public UsersPage(UsersPageViewModel vm, ICurrentUser currentUser)
    {
        _currentUser = currentUser;
        BindingContext = vm;
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        if (!_currentUser.IsAuthenticated)
        {
            BindingContext.As<UsersPageViewModel>().Items.Clear();
        }
    }
}