
namespace StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname
{
    internal class GetUsersByNicknameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetUsersByNicknameRequest, User>
    {
        public async Task<User> Handle(GetUsersByNicknameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.nickname.ToLower();

            return await unitOfWork.UserRepository
                .FirstOrDefaultAsync(a => a.UserName == request.nickname);
        }
    }
}
