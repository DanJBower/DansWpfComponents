using DansWpfComponents.Enums;
using System.Windows;
using System.Windows.Controls;
using ScrollBarVisibility = DansWpfComponents.Enums.ScrollBarVisibility;

namespace DansWpfComponents.Components;

public class ScrollableTabControl : TabControl
{
    static ScrollableTabControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollableTabControl), new FrameworkPropertyMetadata(typeof(ScrollableTabControl)));
    }

    public static readonly DependencyProperty TabLayoutProperty =
        DependencyProperty.Register(
            "TabLayout",
            typeof(TabLayout),
            typeof(ScrollableTabControl),
            new PropertyMetadata(TabLayout.Scroll));

    public static readonly DependencyProperty ScrollBarVisibilityProperty =
        DependencyProperty.Register(
            "ScrollBarVisibility",
            typeof(ScrollBarVisibility),
            typeof(ScrollableTabControl),
            new PropertyMetadata(ScrollBarVisibility.VisibleOnHorizontal));

    public static readonly DependencyProperty ScrollBarPositionProperty =
        DependencyProperty.Register(
            "ScrollBarPosition",
            typeof(ScrollBarPosition),
            typeof(ScrollableTabControl),
            new PropertyMetadata(Enums.ScrollBarPosition.Outside));

    public TabLayout TabLayout
    {
        get => (TabLayout)GetValue(TabLayoutProperty);
        set => SetValue(TabLayoutProperty, value);
    }

    public ScrollBarVisibility ScrollBarVisibility
    {
        get => (ScrollBarVisibility)GetValue(ScrollBarVisibilityProperty);
        set => SetValue(ScrollBarVisibilityProperty, value);
    }

    public ScrollBarPosition ScrollBarPosition
    {
        get => (ScrollBarPosition)GetValue(ScrollBarPositionProperty);
        set => SetValue(ScrollBarPositionProperty, value);
    }
}
