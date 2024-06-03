

namespace StarLens.Applicationn.MountUseCases.Queries.GetAllMounts
{
    internal class GetAllMountsHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllMountsRequest, IEnumerable<Mount>>
    {
        public async Task<IEnumerable<Mount>> Handle(GetAllMountsRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.MountRepository.ListAllAsync(cancellationToken);
        }
    }
}
