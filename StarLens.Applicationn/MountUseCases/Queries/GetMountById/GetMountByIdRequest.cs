using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.MountUseCases.Queries.GetMountById
{
    public sealed record GetMountByIdRequest(int Id) : IRequest<IEnumerable<Mount>>
    { }
}
