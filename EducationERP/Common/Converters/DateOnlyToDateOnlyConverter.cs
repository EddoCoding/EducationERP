using System.Globalization;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class DateOnlyToDateOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateOnly dateTime && dateTime == DateOnly.MinValue) return string.Empty;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try { return DateOnly.ParseExact((string)value, "dd.MM.yyyy", CultureInfo.InvariantCulture); }
            catch { return DateOnly.MinValue; }
        }
    }
}