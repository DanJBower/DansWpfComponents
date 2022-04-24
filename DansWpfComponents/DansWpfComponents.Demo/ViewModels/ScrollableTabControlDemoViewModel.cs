using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;
using DansWpfComponents.Enums;

namespace DansWpfComponents.Demo.ViewModels;

public partial class ScrollableTabControlDemoViewModel : DemoViewModel
{
    public ScrollableTabControlDemoViewModel() : base($"{nameof(ScrollableTabControl)} Demo") { }

    [ObservableProperty]
    private TabLayout _tabLayout;

    [ObservableProperty]
    private ScrollBarVisibility _scrollBarVisibility;

    [ObservableProperty]
    private ScrollBarPositions _scrollBarPosition;
}

// Note to self, this is the going to be the application one, so when you make changes in here, it will update the main application. Much wow 🙂
