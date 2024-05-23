
namespace StarLens.Applicationn.UserUseCases.Queries.GetUserByEmail
{
    public sealed record GetUserByEmailRequest(string email) : IRequest<User>
    {

    }
}
