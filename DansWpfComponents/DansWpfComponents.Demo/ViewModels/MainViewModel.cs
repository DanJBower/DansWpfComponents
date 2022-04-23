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

    public MainViewModel()
    {
        WelcomeViewModel welcome = new();

        Demos.Add(welcome);
        CurrentDemo = welcome;
    }
}
