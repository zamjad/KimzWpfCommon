using System;
using System.Globalization;
using System.Windows.Data;

namespace KimzWpfCommon.Converter
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class NegationConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var condition = (bool?) value;
            return !condition;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? condition = (bool?) value;
            return !condition;
        }
    }
}
