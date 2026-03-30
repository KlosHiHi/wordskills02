using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Day1.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _text = "Привет Авалония!";

        [RelayCommand]
        private void ChangeText()
        {
            Text = "Поменяный текст";
        }
    }
}
