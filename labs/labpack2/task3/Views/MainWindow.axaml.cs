using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using task3.Services;
using task3.ViewModels;

namespace task3.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = App.Services.GetRequiredService<MainViewModel>();
        }
    }
}