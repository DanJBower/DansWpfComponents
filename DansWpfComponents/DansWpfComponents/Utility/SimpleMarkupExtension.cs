using System;
using System.Windows.Markup;

namespace DansWpfComponents.Utility;

public abstract class SimpleMarkupExtension : MarkupExtension
{
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}
