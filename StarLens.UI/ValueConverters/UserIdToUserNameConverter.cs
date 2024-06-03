using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ValueConverters
{
    internal class UserIdToUserNameConverter : IValueConverter
    {
        private readonly IMediator _mediator;
        public UserIdToUserNameConverter()
        {
             _mediator = DependencyService.Resolve<IMediator>();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetName((int)value).Result;
        }
        private async Task<string> GetName(int id)
        {
            return (await _mediator.Send(new GetUserByIdRequest(id))).UserName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
