using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace DansWpfComponents.Utility;

public class PropertiesToCollectionConverter : MarkupExtension
{
    private readonly Type _type;
    private readonly Type _propertyType;

    public PropertiesToCollectionConverter(Type type, Type propertyType)
    {
        _type = type;
        _propertyType = propertyType;
    }

    public override object ProvideValue(IServiceProvider _)
    {
        var result = new List<Tuple<dynamic, string>>().Select(t => new { Value = t.Item1, Name = t.Item2 }).ToList();

        foreach (PropertyInfo propertyInfo in typeof(Brushes).GetProperties())
        {
            object property = propertyInfo.GetValue(_type, null);
            if (property?.GetType() == _propertyType)
            {
                result.Add(new
                {
                    Value = Convert.ChangeType(property, _propertyType),
                    Name = propertyInfo.Name,
                });
            }
        }

        return result;
    }
}
