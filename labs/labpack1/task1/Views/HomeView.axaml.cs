using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using task1.ViewModels;

namespace task1.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
}