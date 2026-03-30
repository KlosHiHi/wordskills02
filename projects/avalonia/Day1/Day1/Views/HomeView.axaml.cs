using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Day1.ViewModels;

namespace Day1.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }
}