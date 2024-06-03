using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.SubscriptionUseCases.Queries.GetUserSubscribes
{
    public sealed record GetUserSubscribesRequest(int Id) : IRequest<IEnumerable<Subscription>>
    { }
}
