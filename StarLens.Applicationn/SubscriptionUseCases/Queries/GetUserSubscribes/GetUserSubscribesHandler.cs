
namespace StarLens.Applicationn.SubscriptionUseCases.Queries.GetUserSubscribes
{
    internal class GetUserSubscribesHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetUserSubscribesRequest, IEnumerable<Subscription>>
    {
        public async Task<IEnumerable<Subscription>> Handle(GetUserSubscribesRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SubscriptionRepository.ListAsync(p => p.User == request.Id);
        }
    }
}
