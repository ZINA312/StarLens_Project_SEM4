using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.SubscriptionUseCases.Commands.RemoveSubscription
{
    public sealed record RemoveSubscriptionRequest(Subscription subscription) : IRequest<Subscription>
    { }
}
