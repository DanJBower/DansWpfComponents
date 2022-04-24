﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DansWpfComponents.Utility;

public class BoolInverterConverter : BaseConverter, IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolToConvert)
        {
            return !boolToConvert;
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolToConvert)
        {
            return !boolToConvert;
        }
        return false;
    }
}
