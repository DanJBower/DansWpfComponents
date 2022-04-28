using System;
using System.Globalization;
using System.Windows.Data;

namespace DansWpfComponents.Utility;

public abstract class MarkupValueConverter : SimpleMarkupExtension, IValueConverter
{
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
