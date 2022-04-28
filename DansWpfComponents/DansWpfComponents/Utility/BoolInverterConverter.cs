using System;
using System.Globalization;

namespace DansWpfComponents.Utility;

public class BoolInverterConverter : MarkupValueConverter
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolToConvert)
        {
            return !boolToConvert;
        }
        return false;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolToConvert)
        {
            return !boolToConvert;
        }
        return false;
    }
}
