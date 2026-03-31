using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using task3.Services;

namespace task3.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentPage => navService.CurrentPage;

        public static NavigationService navService = new();

        public MainViewModel()
        {
            navService.NavigateTo(new RegistrationViewModel());
        }

        [RelayCommand]
        private void OpenAuthPage()
        {
            navService.NavigateTo(new AuthorizationViewModel());
            OnPropertyChanged(nameof(CurrentPage));
        }

        [RelayCommand]
        private void OpenRegPage()
        {
            navService.NavigateTo(new RegistrationViewModel()); 
            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
