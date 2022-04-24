using DansWpfComponents.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DansWpfComponents.Components;

public class CollapsibleRow : RowDefinition
{
    // Test
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

    // For when I forget in future
    // This attached property goes on the parent grid and if a CollapsedRow is collapsed,
    // it will also set Visibility.Collapsed on all objects in those rows. Making them
    // not selectable / hit testable.
    public static readonly DependencyProperty ElementsCollapsedInCollapsedRowsProperty =
        DependencyProperty.RegisterAttached(
            "ElementsCollapsedInCollapsedRows",
            typeof(bool),
            typeof(CollapsibleRow),
            new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender,
                OnSyncWithCollapsibleRows
            ));

    public static void SetElementsCollapsedInCollapsedRows(Grid element, bool value) =>
        element.SetValue(ElementsCollapsedInCollapsedRowsProperty, value);

    public static bool GetSyncCollapsibleRows(Grid element) =>
        (bool)element.GetValue(ElementsCollapsedInCollapsedRowsProperty);

    private static void OnSyncWithCollapsibleRows(
        DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is not Grid grid) return;

        grid.Loaded += SyncControlsInCollapsibleRows;
        grid.Unloaded -= SyncControlsInCollapsibleRows;
    }

    private static void SyncControlsInCollapsibleRows(
        object sender,
        RoutedEventArgs routedEventArgs)
    {
        SetBindingForControlsInCollapsibleRows((Grid)sender);
    }

    private static void SetBindingForControlsInCollapsibleRows(Grid grid)
    {
        for (int i = 0; i < grid.RowDefinitions.Count; i++)
        {
            if (grid.RowDefinitions[i] is CollapsibleRow row)
            {
                ElementsInRow(grid, i).ToList().ForEach(uiElement => SyncUiElementWithRow(uiElement, row));
            }
        }
    }

    private static IEnumerable<UIElement> ElementsInRow(
        Grid grid,
        int rowIndex)
    {
        List<UIElement> childrenInRow = grid.Children.OfType<UIElement>()
            .Where(uiElement => Grid.GetRow(uiElement) == rowIndex)
            .ToList();

        return childrenInRow.Any(uiElement => uiElement is Panel) ? GetChildrenFromPanels(childrenInRow) : childrenInRow;
    }

    private static IEnumerable<UIElement> GetChildrenFromPanels(
        IEnumerable<UIElement> elements)
    {
        Queue<UIElement> queue = new(elements);

        while (queue.Count != 0)
        {
            UIElement uiElement = queue.Dequeue();

            if (uiElement is Panel panel)
            {
                foreach (UIElement child in panel.Children)
                {
                    queue.Enqueue(child);
                }
            }
            else
            {
                yield return uiElement;
            }
        }
    }

    private static readonly BoolInverterConverter BoolInverterConverter = new();

    private static void SyncUiElementWithRow(DependencyObject dependencyObject, CollapsibleRow row)
    {
        BindingOperations.SetBinding(dependencyObject, UIElement.FocusableProperty, new Binding
        {
            Path = new PropertyPath(CollapsedProperty),
            Source = row,
            Converter = BoolInverterConverter
        });
    }
}
