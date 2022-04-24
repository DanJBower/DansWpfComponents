using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace DansWpfComponents.Utility;

public static class EnumUtilities
{
    public static string GetDescription(
        this Enum enumerationValue,
        bool fallbackOnName = true)
    {
        Type enumType = enumerationValue.GetType();

        FieldInfo field;
        try
        {
            field = enumType.GetField(enumerationValue.ToString());
        }
        catch (Exception ex) when (ex is ArgumentNullException or NotSupportedException)
        {
            return string.Empty;
        }

        if (field != null &&
            Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute descriptionAttribute)
        {
            return descriptionAttribute.Description;
        }

        return fallbackOnName ? enumerationValue.ToString() : string.Empty;
    }

    public static IEnumerable<T> GetAllItems<T>(this Enum value)
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static IEnumerable<T> GetAllItems<T>() where T : struct
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }

    public static IEnumerable<T> GetAllSelectedItems<T>(this Enum value)
    {
        int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);

        foreach (object item in Enum.GetValues(typeof(T)))
        {
            int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

            if (itemAsInt == (valueAsInt & itemAsInt))
            {
                yield return (T)item;
            }
        }
    }

    public static IEnumerable<T> GetAllSelectedItems<T>(this int value)
    {
        foreach (object item in Enum.GetValues(typeof(T)))
        {
            int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

            if (itemAsInt == (value & itemAsInt))
            {
                yield return (T)item;
            }
        }
    }

    public static IEnumerable<T> GetAllSelectedItems<T>(this uint value)
    {
        foreach (object item in Enum.GetValues(typeof(T)))
        {
            int itemAsInt = Convert.ToInt32(item, CultureInfo.InvariantCulture);

            if (itemAsInt == (value & itemAsInt))
            {
                yield return (T)item;
            }
        }
    }

    public static bool Contains<T>(this Enum value, T request)
    {
        int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
        int requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);

        return requestAsInt == (valueAsInt & requestAsInt);
    }
}
