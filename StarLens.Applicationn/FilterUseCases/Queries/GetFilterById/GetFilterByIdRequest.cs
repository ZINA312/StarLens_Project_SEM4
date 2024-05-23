using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.FilterUseCases.Queries.GetFilterById
{
    public sealed record GetFilterByIdRequest(int Id) : IRequest<IEnumerable<Filter>>
    { }
}
