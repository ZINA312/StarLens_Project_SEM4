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
                        return "Пользователь";
                    case 1:
                        return "Модератор";
                    case 2:
                        return "Админ";
                    default:
                        return "Неизвестный статус";
                }
            }
            return "Неизвестный статус";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
