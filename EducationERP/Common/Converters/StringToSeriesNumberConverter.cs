using System.Globalization;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class StringToSeriesNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                str = str.Replace(" ", "");

                if (str.Length > 4) str = str.Insert(4, " ").Insert(2, " ");
                else if (str.Length > 2) str = str.Insert(2, " ");

                return str;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str) return str.Replace(" ", "");

            return value;
        }
    }
}