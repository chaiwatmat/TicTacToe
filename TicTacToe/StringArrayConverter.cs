using System;
using System.Globalization;
using System.Windows.Data;

namespace TicTacToe
{
    public class StringArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = int.Parse(parameter.ToString());
            string[] values = (string[])value;

            return values[index];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
