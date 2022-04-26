using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;
using DansWpfComponents.Enums;

namespace DansWpfComponents.Demo.ViewModels;

public partial class FlippableScrollViewerDemoViewModel : DemoViewModel
{
    public FlippableScrollViewerDemoViewModel() : base($"{nameof(FlippableScrollViewer)} Demo") { }

    [ObservableProperty]
    private HorizontalScrollBarPosition _horizontalScrollBarPosition = HorizontalScrollBarPosition.Bottom;

    [ObservableProperty]
    private VerticalScrollBarPosition _verticalScrollBarPosition = VerticalScrollBarPosition.Right;

    [ObservableProperty]
    private bool _scrollHorizontalWhenNoVertical;

    [ObservableProperty]
    private bool _shiftScrollsHorizontallyScrolls = true;
}
