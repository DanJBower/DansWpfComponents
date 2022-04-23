using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DansWpfComponents.Utility;

public class BoolVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length > 0 && values[0] is bool collapsed)
        {
            if (values.Length > 1 && values[1] is bool invert && invert)
            {
                collapsed = !collapsed;
            }

            return collapsed ? Visibility.Collapsed : Visibility.Visible;
        }

        return Visibility.Collapsed;
    }

    public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
