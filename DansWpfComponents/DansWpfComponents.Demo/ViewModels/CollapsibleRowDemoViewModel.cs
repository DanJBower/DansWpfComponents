using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;

namespace DansWpfComponents.Demo.ViewModels;

public partial class CollapsibleRowDemoViewModel : DemoViewModel
{
    public CollapsibleRowDemoViewModel() : base($"{nameof(CollapsibleRow)} Demo") { }

    [ObservableProperty]
    private bool _isCollapsed;
}
