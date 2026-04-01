using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using task3.Services;

namespace task3.ViewModels
{
    public partial class AuthorizationViewModel(NavigationService navigation) : ViewModelBase
    {
        private readonly NavigationService _navigation = navigation;

        [ObservableProperty]
        private float celcius = 232;

        [ObservableProperty]
        private string login;

        [RelayCommand]
        private void CheckLogin()
        {
            //_navigation.NavigateTo<RegistrationViewModel>(x=>x.Login = this.Login);
        }

        [RelayCommand]
        private void OnRegPage()
        {
            _navigation.NavigateTo<RegistrationViewModel>();
        }
    }
}
