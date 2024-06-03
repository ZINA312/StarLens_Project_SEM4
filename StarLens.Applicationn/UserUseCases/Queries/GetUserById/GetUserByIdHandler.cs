
namespace StarLens.Applicationn.UserUseCases.Queries.GetUserById
{
    internal class GetUserByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetUserByIdRequest, User>
    {
        public async Task<User> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.UserRepository.FirstOrDefaultAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
