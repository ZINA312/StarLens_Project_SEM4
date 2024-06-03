using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CommentUseCases.Queries.GetCommentsByManyIds
{
    public sealed record GetCommentsByManyIdsRequest(List<int> Ids) : IRequest<IEnumerable<Comment>>
    { }
}
