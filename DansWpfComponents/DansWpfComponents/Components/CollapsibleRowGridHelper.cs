using DansWpfComponents.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DansWpfComponents.Components;

public class CollapsibleRowGridHelper : DependencyObject
{
    public static readonly DependencyProperty SyncCollapsibleRowsProperty =
        DependencyProperty.RegisterAttached(
            "SyncCollapsibleRows",
            typeof(bool),
            typeof(CollapsibleRowGridHelper),
            new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender,
                OnSyncWithCollapsibleRows
            ));

    public static void SetSyncCollapsibleRows(
        UIElement element,
        bool value)
    {
        element.SetValue(SyncCollapsibleRowsProperty, value);
    }

    private static void OnSyncWithCollapsibleRows(
        DependencyObject dependencyObject,
        DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        if (dependencyObject is Grid grid)
        {
            grid.Loaded += SyncControlsInCollapsibleRows;
            grid.Unloaded -= SyncControlsInCollapsibleRows;
        }
    }

    private static void SyncControlsInCollapsibleRows(
        object sender,
        RoutedEventArgs routedEventArgs)
    {
        SetBindingForControlsInCollapsibleRows((Grid)sender);
    }

    private static IEnumerable<UIElement> GetChildrenFromPanels(
        IEnumerable<UIElement> elements)
    {
        Queue<UIElement> queue = new(elements);

        while (queue.Any())
        {
            UIElement uiElement = queue.Dequeue();
            if (uiElement is Panel panel)
            {
                foreach (UIElement child in panel.Children) queue.Enqueue(child);
            }
            else
            {
                yield return uiElement;
            }
        }
    }

    private static IEnumerable<UIElement> ElementsInRow(
        Grid grid,
        int rowIndex)
    {
        IEnumerable<UIElement> rowRootElements = grid.Children.OfType<UIElement>().Where(c => Grid.GetRow(c) == rowIndex);
        IEnumerable<UIElement> elementsInRow = rowRootElements.ToList();

        return elementsInRow.Any(e => e is Panel) ? GetChildrenFromPanels(elementsInRow) : elementsInRow;
    }

    private static readonly BoolInverterConverter BoolInverterConverter = new();

    private static void SyncUiElementWithRow(DependencyObject dependencyObject, CollapsibleRow row)
    {
        BindingOperations.SetBinding(dependencyObject, UIElement.FocusableProperty, new Binding
        {
            Path = new PropertyPath(CollapsibleRow.CollapsedProperty),
            Source = row,
            Converter = BoolInverterConverter
        });
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
}