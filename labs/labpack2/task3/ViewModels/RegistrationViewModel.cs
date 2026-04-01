using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using task3.Services;

namespace task3.ViewModels
{
    public partial class RegistrationViewModel(NavigationService navigation) : ViewModelBase
    {
        private readonly NavigationService _navigation = navigation;

        [ObservableProperty]
        private string login;

        [RelayCommand]
        private void Registration()
        {
            _navigation.NavigateTo<AuthorizationViewModel>(x => x.Login = this.Login);
        }
    }
}
