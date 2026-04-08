using Avalonia.Controls;
using TechApp.ViewModels;

namespace TechApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}