

namespace StarLens.Applicationn.MountUseCases.Queries.GetMountById
{
    internal class GetMountByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetMountByIdRequest, IEnumerable<Mount>>
    {
        public async Task<IEnumerable<Mount>> Handle(GetMountByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.MountRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
   
}
