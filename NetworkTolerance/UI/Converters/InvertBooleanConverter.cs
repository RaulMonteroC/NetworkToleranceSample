using System;
using System.Globalization;
using Xamarin.Forms;

namespace NetworkTolerance.UI.Converters
{
    public class InvertBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = (bool) value;

            return !flag;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var flag = (bool) value;

            return !flag;
        }
    }
}