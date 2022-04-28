using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace DansWpfComponents.Utility;

public class PropertiesToCollectionConverter<T> : MarkupExtension
{
    private readonly Type _type;

    public PropertiesToCollectionConverter(Type type)
    {
        _type = type;
    }

    public override object ProvideValue(IServiceProvider _)
    {
        var result = new List<Tuple<T, string>>().Select(t => new { Value = t.Item1, Name = t.Item2 }).ToList();

        foreach (PropertyInfo propertyInfo in typeof(Brushes).GetProperties())
        {
            if (propertyInfo.GetValue(_type, null) is T property)
            {
                result.Add(new
                {
                    Value = property,
                    Name = propertyInfo.Name,
                });
            }
        }

        return result;
    }
}
