using System.Globalization;
using System.Windows.Data;

namespace EducationERP.Common.Converters
{
    public class TimeOnlyToTimeOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeOnly time && time == TimeOnly.MinValue) return string.Empty;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try { return TimeOnly.ParseExact((string)value, "HH:mm", CultureInfo.InvariantCulture); }
            catch { return TimeOnly.MinValue; }
        }
    }
}
