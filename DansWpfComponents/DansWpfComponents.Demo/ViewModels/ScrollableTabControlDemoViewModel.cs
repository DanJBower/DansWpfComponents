using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;
using DansWpfComponents.Enums;
using System.Windows.Controls;
using ScrollBarVisibility = DansWpfComponents.Enums.ScrollBarVisibility;

namespace DansWpfComponents.Demo.ViewModels;

public partial class ScrollableTabControlDemoViewModel : DemoViewModel
{
    public ScrollableTabControlDemoViewModel() : base($"{nameof(ScrollableTabControl)} Demo") { }

    [ObservableProperty]
    private TabLayout _tabLayout = TabLayout.Scroll;

    [ObservableProperty]
    private ScrollBarVisibility _scrollBarVisibility = ScrollBarVisibility.Visible;

    [ObservableProperty]
    private ScrollBarPosition _scrollBarPosition = ScrollBarPosition.Outside;

    [ObservableProperty]
    private Dock _tabStripPlacement = Dock.Top;
}
