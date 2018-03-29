using System;
using System.Diagnostics;
using System.Windows.Data;
using System.Windows.Markup;

namespace KimzWpfCommon.MarkupExtensions
{
    public class TraceBindingExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var target = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

            if (!(target?.TargetObject is Binding binding)) return null;

            Debug.WriteLine("Path = " + binding.Path.Path);
            Debug.WriteLine("Mode = " + binding.Mode);
            Debug.WriteLine("FallbackValue = " + binding.FallbackValue);
            Debug.WriteLine("Source = " + binding.Source);
            Debug.WriteLine("ElementName = " + binding.ElementName);
            Debug.WriteLine("Converter = " + binding.Converter);
            return null;
        }
    }
}
