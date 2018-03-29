using System;
using System.Drawing;
using System.Linq;
using System.Windows.Markup;

namespace KimzWpfCommon.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(string))]
    public class ColorExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetNames(typeof(KnownColor)).ToList();
        }
    }
}
