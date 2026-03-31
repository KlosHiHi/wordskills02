using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace task2
{
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }

        public static ServiceProvider Services { get; private set; }
        

        public override void Initialize()
        {
            ConfigurationBuilder builder = new();
            builder.AddJsonFile("Options/appsettings.json");
            Configuration = builder.Build();

            var collection = new ServiceCollection();
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