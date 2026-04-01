using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using task3.Services;
using task3.ViewModels;

namespace task3.Views;

public partial class AuthorizationView : UserControl
{
    public AuthorizationView()
    {
        InitializeComponent();
        //DataContext = new AuthorizationViewModel(new NavigationService());
    }
}