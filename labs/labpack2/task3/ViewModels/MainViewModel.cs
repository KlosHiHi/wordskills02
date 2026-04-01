using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using task3.Services;

namespace task3.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;

        public ViewModelBase CurrentPage => _navigation.CurrentPage;

        public MainViewModel(NavigationService navigation)
        {
            _navigation = navigation;
            _navigation.PropertyChanged += _navigation_Navigated;
            _navigation.NavigateTo<RegistrationViewModel>();
        }

        private void _navigation_Navigated(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentPage));
        }

        [RelayCommand]
        private void OpenAuthPage()
        {
            _navigation.NavigateTo<AuthorizationViewModel>();
        }

        [RelayCommand]
        private void OpenRegPage()
        {
            _navigation.NavigateTo<RegistrationViewModel>();
        }
    }
}
