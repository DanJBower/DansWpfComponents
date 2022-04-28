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

    public MainViewModel(
        WelcomeViewModel welcomeViewModel,
        CollapsibleRowDemoViewModel collapsibleRowDemoViewModel,
        ScrollableTabControlDemoViewModel scrollableTabControlDemoViewModel,
        FlippableScrollViewerDemoViewModel flippableScrollViewerDemoViewModel,
        BlurredHolderDemoViewModel blurredHolderDemoViewModel)
    {
        ScrollableTabControlDemoViewModel = scrollableTabControlDemoViewModel;

        Demos.Add(welcomeViewModel);
        Demos.Add(collapsibleRowDemoViewModel);
        Demos.Add(ScrollableTabControlDemoViewModel);
        Demos.Add(flippableScrollViewerDemoViewModel);
        Demos.Add(blurredHolderDemoViewModel);

        CurrentDemo = welcomeViewModel;
    }
}
