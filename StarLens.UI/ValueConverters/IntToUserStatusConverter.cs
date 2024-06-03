using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ValueConverters
{
    internal class IntToUserStatusConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is int status)
            {
                switch (status)
                {
                    case 0:
                        return "User";
                    case 1:
                        return "Moderator";
                    case 2:
                        return "Admin";
                    default:
                        return "Unknown status";
                }
            }
            return "Unknown status";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
