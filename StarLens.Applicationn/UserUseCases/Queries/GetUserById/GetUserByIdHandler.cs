
namespace StarLens.Applicationn.UserUseCases.Queries.GetUserById
{
    internal class GetUserByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetUserByIdRequest, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.UserRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
