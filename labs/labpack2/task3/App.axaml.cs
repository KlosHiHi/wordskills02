using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using task3.Services;
using task3.ViewModels;
using task3.Views;

namespace task3
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; }

        public override void Initialize()
        {
            var collection = new ServiceCollection()
                .AddSingleton<NavigationService>()
                .AddSingleton<MainViewModel>()
                .AddTransient<RegistrationViewModel>()
                .AddTransient<AuthorizationViewModel>();
            Services = collection.BuildServiceProvider();

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}