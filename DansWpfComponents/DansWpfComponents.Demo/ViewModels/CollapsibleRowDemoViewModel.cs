using CommunityToolkit.Mvvm.ComponentModel;

namespace DansWpfComponents.Demo.ViewModels;

public partial class CollapsibleRowDemoViewModel : DemoViewModel
{
    public CollapsibleRowDemoViewModel() : base("Collapsible Row Demo") { }

    [ObservableProperty]
    private bool _isCollapsed;
}
