using System;
using System.Globalization;
using System.Windows.Data;

namespace DansWpfComponents.Utility;

public abstract class MarkupMultiValueConverter : SimpleMarkupExtension, IMultiValueConverter
{
    public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

    public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
