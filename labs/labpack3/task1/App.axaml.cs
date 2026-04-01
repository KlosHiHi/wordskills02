using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using task1.Contexts;
using task1.Services;
using task1.Views;

namespace task1
{
    public partial class App : Application
    {
        public static ServiceProvider Services { get; private set; }

        public override void Initialize()
        {
            var collections = new ServiceCollection()
                .AddDbContext<AppDpContext>()
                .AddSingleton<UserService>();

            Services = collections.BuildServiceProvider();
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