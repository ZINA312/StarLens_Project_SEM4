using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAccessoryByName
{
    public sealed record GetAccessoryByNameRequest(string name) : IRequest<IEnumerable<Accessory>>
    { }
}
