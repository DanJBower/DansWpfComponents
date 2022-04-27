using DansWpfComponents.Demo.ViewModels;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DansWpfComponents.Demo;

public partial class App
{
    private readonly IContainer _container;

    public App()
    {
        ServiceCollection services = new();
        ConfigureServices(services);

        _container = new Container();
        _container.Populate(services);
    }

    private void DemoStartup(object sender, StartupEventArgs e)
    {
        MainWindow mainWindow = _container.GetService<MainWindow>();
        mainWindow?.Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Register the main view model
        services.AddTransient<MainViewModel>();

        // Register all demo view models
        services.Scan(scan => scan.FromCallingAssembly()
            .AddClasses(classes => classes.AssignableTo<DemoViewModel>(), false)
            .AsSelf()
            .WithTransientLifetime());

        // Register the main window
        services.AddTransient<MainWindow>();
    }
}
