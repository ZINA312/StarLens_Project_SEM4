
namespace StarLens.Applicationn.UserUseCases.Queries.GetUserById
{
    public sealed record GetUserByIdRequest(int Id) : IRequest<User>
    { }
}
