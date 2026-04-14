using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase _content = null!;

    [ObservableProperty]
    private string _title = "Главная";

    [RelayCommand]
    private void ToOrderPage()
    {
        Content = new OrderListViewModel();
    }

    [RelayCommand]
    private void ToExtruderPage()
    {
        Content = new ExtruderViewModel();
    }

    [RelayCommand]
    private void ToEventPage()
    {
        Content = new EventViewModel();
    }
}
