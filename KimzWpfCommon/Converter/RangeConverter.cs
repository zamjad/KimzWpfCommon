using System;
using System.Globalization;
using System.Windows.Data;

namespace KimzWpfCommon.Converter
{
    public class RangeConverter : IValueConverter
    {
        public  int Minimum { get; set; }

        public int Maximum { get; set; }

        public RangeConverter()
        {

        }

        public RangeConverter(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int data = (int)value;

            return data >= Minimum && data <= Maximum;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
