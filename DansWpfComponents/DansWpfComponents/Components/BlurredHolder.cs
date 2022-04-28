using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DansWpfComponents.Components;

public class BlurredHolder : UserControl
{
    static BlurredHolder()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(BlurredHolder), new FrameworkPropertyMetadata(typeof(BlurredHolder)));
    }

    public static readonly DependencyProperty BlurOverlayEnabledProperty =
        DependencyProperty.Register(
            "BlurOverlayEnabled",
            typeof(bool),
            typeof(BlurredHolder),
            new PropertyMetadata(true));

    public static readonly DependencyProperty BlurOverlayColorProperty =
        DependencyProperty.Register(
            "BlurOverlayColor",
            typeof(Brush),
            typeof(BlurredHolder),
            new PropertyMetadata(Brushes.White));

    public static readonly DependencyProperty BlurOverlayOpacityProperty =
        DependencyProperty.Register(
            "BlurOverlayOpacity",
            typeof(double),
            typeof(BlurredHolder),
            new PropertyMetadata(1.0));

    public static readonly DependencyProperty BlurOverlayStrengthProperty =
        DependencyProperty.Register(
            "BlurOverlayStrength",
            typeof(double),
            typeof(BlurredHolder),
            new PropertyMetadata(0.0));

    public static readonly DependencyProperty BlurOverlayKernelTypeProperty =
        DependencyProperty.Register(
            "BlurOverlayKernelType",
            typeof(KernelType),
            typeof(BlurredHolder),
            new PropertyMetadata(KernelType.Gaussian));

    public bool BlurOverlayEnabled
    {
        get => (bool)GetValue(BlurOverlayEnabledProperty);
        set => SetValue(BlurOverlayEnabledProperty, value);
    }

    public Brush BlurOverlayColor
    {
        get => (Brush)GetValue(BlurOverlayColorProperty);
        set => SetValue(BlurOverlayColorProperty, value);
    }

    public double BlurOverlayOpacity
    {
        get => (double)GetValue(BlurOverlayOpacityProperty);
        set => SetValue(BlurOverlayOpacityProperty, value);
    }

    public double BlurOverlayStrength
    {
        get => (double)GetValue(BlurOverlayStrengthProperty);
        set => SetValue(BlurOverlayStrengthProperty, value);
    }

    public KernelType BlurOverlayKernelType
    {
        get => (KernelType)GetValue(BlurOverlayKernelTypeProperty);
        set => SetValue(BlurOverlayKernelTypeProperty, value);
    }
}
