using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using task1.Models;
using task1.Services;

namespace task1.ViewModels
{
    public partial class DBManagerViewModel(UserService service) : ViewModelBase
    {
        private UserService _userService = service;

        [ObservableProperty]
        private string _login;

        [ObservableProperty]
        private string _password;

        public List<User> Users => _userService.GetUsers();

        [RelayCommand]
        private async Task InsertUser()
        {
            var login = Login;
            var password = Password;
            var user = new User() { Login = login, Password = password };
            await _userService.InsertUserAsync(user);
            OnPropertyChanged(nameof(Users));
        }

        [RelayCommand]
        private async Task Update(User user)
        {

            OnPropertyChanged(nameof(Users));
        }

        [RelayCommand]
        private async Task Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            OnPropertyChanged(nameof(Users));
        }
    }
}
