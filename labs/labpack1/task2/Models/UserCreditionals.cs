using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace task2.ViewModels
{
    public partial class UserCreditionals : ObservableValidator
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле логина не должно быть пустым")]
        [MinLength(3, ErrorMessage = "Логин должен состоять минимум из 3 символов")]
        [MaxLength(20, ErrorMessage = "Логин может состоять максимум из 20 символов")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Логин может состоять только из латинских символов")]
        private string login;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле пароля не должно быть пустым")]
        [MinLength(9, ErrorMessage = "Пароль должен быть минимум из 8 символов")]
        private string password;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле подтверждения пароля не должно быть пустым")]
        private string repeatPassword;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле почты не должно быть пустым")]
        [EmailAddress(ErrorMessage = "При наборе почты произошл ошибка")]
        private string email;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Поле телефона не должно быть пустым")]
        [Phone(ErrorMessage = "При наборе пароля произошла ошибка")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&]).+$", ErrorMessage = "Пароль должен содержать латинские буквы верхнего и нижнего регистра, спецсимволы")]
        private string phone;
    }
}
