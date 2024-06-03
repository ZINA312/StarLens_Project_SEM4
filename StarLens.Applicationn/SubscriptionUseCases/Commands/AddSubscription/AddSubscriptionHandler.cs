using StarLens.Applicationn.PublicationUseCases.Commands.AddPublication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.SubscriptionUseCases.Commands.AddSubscription
{
    internal class AddSubscriptionHandler : IRequestHandler<AddSubscriptionRequest, Subscription>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddSubscriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Subscription> Handle(AddSubscriptionRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.SubscriptionRepository.AddAsync(request.subscription, cancellationToken);
            return request.subscription;
        }
    }
}
