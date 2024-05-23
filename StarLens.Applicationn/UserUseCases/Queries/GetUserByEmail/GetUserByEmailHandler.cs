
namespace StarLens.Applicationn.UserUseCases.Queries.GetUserByEmail
{
    internal class GetUserByEmailHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetUserByEmailRequest, User>
    {
        public async Task<User> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.UserRepository
                .FirstOrDefaultAsync(a => a.Email == request.email);
        }
    }
}
