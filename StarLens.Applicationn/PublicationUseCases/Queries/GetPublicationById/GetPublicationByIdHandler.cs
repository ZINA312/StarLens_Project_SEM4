

namespace StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationById
{
    internal class GetPublicationByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetPublicationByIdRequest, Publication>
    {
        public async Task<Publication> Handle(GetPublicationByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.PublicationRepository.GetByIdAsync(request.Id, cancellationToken);
        }
    }
}
