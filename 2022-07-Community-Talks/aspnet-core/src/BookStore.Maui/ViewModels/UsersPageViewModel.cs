using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace BookStore.Maui.ViewModels
{
    public class UsersPageViewModel : BindableObject, ITransientDependency
    {
        private readonly IIdentityUserAppService _identityUserAppService;
        private readonly ICurrentUser _currentUser;

        public UsersPageViewModel(IIdentityUserAppService identityUserAppService, ICurrentUser currentUser)
        {
            _identityUserAppService = identityUserAppService;
            _currentUser = currentUser;
            GetUsersAsync();
            RefreshCommand = new Command(GetUsersAsync);
        }

        public GetIdentityUsersInput Input { get; } = new();

        public ObservableCollection<IdentityUserDto> Items { get; } = new();

        public ICommand RefreshCommand { get; }

        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value, nameof(IsBusy)); }

        private async void GetUsersAsync()
        {
            if (!_currentUser.IsAuthenticated)
            {
                await Shell.Current.DisplayAlert("Error", "未登录到应用程序.", "Close");
                return;
            }
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;


            Items.Clear();

            var result = await _identityUserAppService.GetListAsync(Input);
            foreach (var user in result.Items)
            {
                Items.Add(user);
            }

            IsBusy = false;

        }

        protected void SetProperty<T>(ref T backField, T value, [CallerMemberName] string propertyName = null)
        {
            backField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
