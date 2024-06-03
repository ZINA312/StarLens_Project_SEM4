

namespace StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationById
{
    public sealed record GetPublicationByIdRequest(int Id) : IRequest<Publication>
    { }
}
