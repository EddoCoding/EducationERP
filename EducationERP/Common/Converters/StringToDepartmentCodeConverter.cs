using System.Globalization;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class StringToDepartmentCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                str = str.Replace(" ", "").Replace("-", "");
                if (str.Length > 3) return str.Insert(3, "-");

                return str;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str) return str.Replace("-", "").Replace(" ", "");

            return value;
        }
    }
}