using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.SubscriptionUseCases.Commands.AddSubscription
{
    public sealed record AddSubscriptionRequest(Subscription subscription) : IRequest<Subscription>
    { }
}
