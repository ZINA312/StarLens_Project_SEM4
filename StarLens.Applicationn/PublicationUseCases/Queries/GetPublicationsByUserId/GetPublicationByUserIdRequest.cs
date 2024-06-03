

namespace StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId
{
    public sealed record GetPublicationByUserIdRequest(int Id) : IRequest<IEnumerable<Publication>>
    { }
}
