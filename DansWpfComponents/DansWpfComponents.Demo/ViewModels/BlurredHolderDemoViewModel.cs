using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DansWpfComponents.Demo.ViewModels;

public partial class BlurredHolderDemoViewModel : DemoViewModel
{
    public BlurredHolderDemoViewModel() : base($"{nameof(BlurredHolder)} Demo") { }

    [ObservableProperty]
    private double _overlayOpacity = 1;

    [ObservableProperty]
    private double _overlayRadius = 10;

    [ObservableProperty]
    private SolidColorBrush _overlayColor = Brushes.Transparent;

    [ObservableProperty]
    private bool _overlayEnabled = true;

    [ObservableProperty]
    private KernelType _overlayKernelType = KernelType.Gaussian;
}
