using System;
using System.Linq;
using System.Windows.Markup;

namespace DansWpfComponents.Utility;

public class EnumToCollectionConverter : MarkupExtension
{
    private readonly Type _type;

    public EnumToCollectionConverter(Type type)
    {
        _type = type;
    }

    public override object ProvideValue(IServiceProvider _)
    {
        return Enum.GetValues(_type)
            .Cast<Enum>()
            .Select(enumValue => new
            {
                Value = enumValue,
                Description = enumValue.GetDescription(),
            });
    }
}
