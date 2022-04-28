using CommunityToolkit.Mvvm.ComponentModel;
using DansWpfComponents.Components;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DansWpfComponents.Demo.ViewModels;

public partial class BlurredHolderDemoViewModel : DemoViewModel
{
    public BlurredHolderDemoViewModel() : base($"{nameof(BlurredHolder)} Demo") { }

    [ObservableProperty]
    private double _overlayOpacity;

    [ObservableProperty]
    private double _overlayStrength;

    [ObservableProperty]
    private SolidColorBrush _overlayColor;

    [ObservableProperty]
    private bool _overlayEnabled;

    [ObservableProperty]
    private KernelType _overlayKernelType;
}
