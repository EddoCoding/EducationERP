using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class StringToNumberSnilsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                str = str.Replace(" ", "").Trim();

                if (str.Length > 11) str = str.Substring(0, 11);

                if (str.Length > 9)
                {
                    str = str.Insert(9, " ");
                    str = str.Insert(6, "-");
                    str = str.Insert(3, "-");
                }
                else if (str.Length > 6)
                {
                    str = str.Insert(6, "-");
                    str = str.Insert(3, "-");
                }
                else if (str.Length > 3) str = str.Insert(3, "-");

                return str;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str) return str.Replace(" ", "").Replace("-", "");

            return value;
        }
    }
}