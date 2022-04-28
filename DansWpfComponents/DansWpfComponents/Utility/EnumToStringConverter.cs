using System;
using System.Globalization;

namespace DansWpfComponents.Utility;

public class EnumToStringConverter : MarkupValueConverter
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Enum enumValue)
        {
            return enumValue.GetDescription();
        }

        return "";
    }
}
