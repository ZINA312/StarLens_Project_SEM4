
namespace StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname
{
    public sealed record GetUsersByNicknameRequest(string nickname) : IRequest<User>
    {

    }

}
