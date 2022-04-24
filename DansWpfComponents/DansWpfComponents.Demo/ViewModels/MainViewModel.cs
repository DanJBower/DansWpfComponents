using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace DansWpfComponents.Demo.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel
{
    [ObservableProperty]
    private ObservableCollection<DemoViewModel> _demos = new();

    [ObservableProperty]
    private DemoViewModel _currentDemo;

    [ObservableProperty]
    private ScrollableTabControlDemoViewModel _scrollableTabControlDemoViewModel;

    public MainViewModel()
    {
        WelcomeViewModel welcome = new();

        ScrollableTabControlDemoViewModel = new();

        Demos.Add(welcome);
        Demos.Add(new CollapsibleRowDemoViewModel());
        Demos.Add(ScrollableTabControlDemoViewModel);
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());
        Demos.Add(new WelcomeViewModel());

        CurrentDemo = welcome;
    }
}
