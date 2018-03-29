using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;

namespace KimzWpfCommon.MarkupExtensions
{
    public class ProcessExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Process.GetProcesses().ToList();
        }
    }
}
