using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.SubscriptionUseCases.Commands.RemoveSubscription
{
    internal class RemoveSubscriptionHandler : IRequestHandler<RemoveSubscriptionRequest, Subscription>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RemoveSubscriptionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Subscription> Handle(RemoveSubscriptionRequest request, CancellationToken cancellationToken)
        {    
            await _unitOfWork.SubscriptionRepository.DeleteAsync(request.subscription);
            return request.subscription;
        }
    }
}
