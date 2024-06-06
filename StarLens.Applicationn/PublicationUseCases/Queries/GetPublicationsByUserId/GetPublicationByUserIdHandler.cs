

using StarLens.Applicationn.UserUseCases.Queries.GetUserById;

namespace StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId
{
    internal class GetPublicationByUserIdHandler(IUnitOfWork unitOfWork, IMediator mediator) :
    IRequestHandler<GetPublicationByUserIdRequest, IEnumerable<Publication>>
    {
        public async Task<IEnumerable<Publication>> Handle(GetPublicationByUserIdRequest request, CancellationToken cancellationToken)
        {
            var publications = await unitOfWork.PublicationRepository.ListAsync(t => t.UserId.Equals(request.Id), cancellationToken);

            foreach (var publication in publications)
            {
                publication.User = await mediator.Send(new GetUserByIdRequest(publication.UserId));
            }

            return publications;
        }
    }
}
