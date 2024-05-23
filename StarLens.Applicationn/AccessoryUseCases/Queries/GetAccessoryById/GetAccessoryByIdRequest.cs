using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAccessoryById
{
    public sealed record GetAccessoryByIdRequest(int Id) : IRequest<IEnumerable<Accessory>>
    { }
}
