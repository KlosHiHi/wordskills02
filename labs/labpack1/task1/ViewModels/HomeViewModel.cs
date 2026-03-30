using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace task1.ViewModels;

public partial class HomeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string text = "Hello Avalonia!";

    [RelayCommand]
    public void ChangeText()
    {
        Text = "Привет Авалония!";
    }
}
