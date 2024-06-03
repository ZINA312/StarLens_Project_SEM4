using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TopicUseCases.Queries.GetTopicsByTitle
{
    public sealed record GetTopicsByTitleRequest(string title) : IRequest<IEnumerable<Topic>>
    {

    }
}
