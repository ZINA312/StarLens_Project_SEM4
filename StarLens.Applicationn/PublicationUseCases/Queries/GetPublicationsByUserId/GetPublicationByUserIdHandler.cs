

namespace StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId
{
    internal class GetPublicationByUserIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetPublicationByUserIdRequest, IEnumerable<Publication>>
    {
        public async Task<IEnumerable<Publication>> Handle(GetPublicationByUserIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PublicationRepository.ListAsync(t => t.UserId.Equals(request.Id), cancellationToken);
        }
    }
}
