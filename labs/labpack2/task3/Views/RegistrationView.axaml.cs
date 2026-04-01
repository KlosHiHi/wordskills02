using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using task3.Services;
using task3.ViewModels;

namespace task3.Views;

public partial class RegistrationView : UserControl
{
    public RegistrationView()
    {
        InitializeComponent();

        //DataContext = new RegistrationViewModel(new NavigationService());
    }
}