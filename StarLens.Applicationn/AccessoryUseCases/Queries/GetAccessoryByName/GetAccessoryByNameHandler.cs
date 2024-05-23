

namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAccessoryByName
{
    internal class GetAccessoryByNameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAccessoryByNameRequest, IEnumerable<Accessory>>
    {
        public async Task<IEnumerable<Accessory>> Handle(GetAccessoryByNameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.name.ToLower();

            return await unitOfWork.AccessoryRepository
                .ListAsync(a => a.Name.ToLower() == searchKeyword ||
                                a.Name.ToLower().StartsWith(searchKeyword) ||
                                a.Name.ToLower().Contains(searchKeyword), cancellationToken);
        }
    }
}
