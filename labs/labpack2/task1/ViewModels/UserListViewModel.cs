using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using task1.Models;

namespace task1.ViewModels
{
    public partial class UserListViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<User> users;

        [ObservableProperty]
        private string login;

        [ObservableProperty]
        private string password;

        public UserListViewModel()
        {
            Users = new()
            {
                new User(){ Login = "UserLoginTest1", Password = "qwerty" },
                new User(){ Login = "UserLoginTest2", Password = "qwerty" },
                new User(){ Login = "UserLoginTest3", Password = "qwerty" },
                new User(){ Login = "UserLoginTest4", Password = "qwerty" },
                new User(){ Login = "UserLoginTest5", Password = "qwerty" },
            };
        }

        [RelayCommand]
        public void Delete(User user)
        {
            Users.Remove(user);
        }

        [RelayCommand]
        public void Add()
        {
            var user = new User() { Login = Login, Password = Password };
            Users.Add(user);
        }
    }
}
