
namespace StarLens.Applicationn.UserUseCases.Queries.SearchUsersByNickname
{
    public sealed record SearchUsersByNicknameRequest(string nickname) : IRequest<IEnumerable<User>>
    {

    }
}
