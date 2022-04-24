using System;
using System.Windows.Markup;

namespace DansWpfComponents.Utility;

public abstract class BaseConverter : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
