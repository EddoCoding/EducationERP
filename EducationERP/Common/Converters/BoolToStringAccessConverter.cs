using System.Globalization;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class BoolToStringAccessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if ((bool)value == true) return "Полный";
                else return "Ограниченный";
            }
            else return "Без доступа";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}