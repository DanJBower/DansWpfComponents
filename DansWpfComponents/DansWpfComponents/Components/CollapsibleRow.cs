using System.Windows;
using System.Windows.Controls;

namespace DansWpfComponents.Components;

public class CollapsibleRow : RowDefinition
{
    public static readonly DependencyProperty CollapsedProperty;

    public bool Collapsed
    {
        get => (bool)GetValue(CollapsedProperty);
        set => SetValue(CollapsedProperty, value);
    }

    static CollapsibleRow()
    {
        CollapsedProperty = DependencyProperty.Register("Collapsed",
            typeof(bool),
            typeof(CollapsibleRow),
            new PropertyMetadata(false, OnCollapsedChanged));

        HeightProperty.OverrideMetadata(typeof(CollapsibleRow),
            new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, CoerceHeight));

        MinHeightProperty.OverrideMetadata(typeof(CollapsibleRow),
            new FrameworkPropertyMetadata(0.0, null, CoerceHeight));

        MaxHeightProperty.OverrideMetadata(typeof(CollapsibleRow),
            new FrameworkPropertyMetadata(double.PositiveInfinity, null, CoerceHeight));
    }

    private static object CoerceHeight(
        DependencyObject dependencyObject,
        object baseValue)
    {
        if (!((CollapsibleRow)dependencyObject).Collapsed)
        {
            return baseValue;
        }

        if (baseValue is GridLength)
        {
            return new GridLength(0);
        }

        return 0.0;
    }

    private static void OnCollapsedChanged(
        DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        dependencyObject.CoerceValue(MinHeightProperty);
        dependencyObject.CoerceValue(HeightProperty);
        dependencyObject.CoerceValue(MaxHeightProperty);
    }
}
