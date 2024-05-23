

namespace StarLens.Applicationn.CameraUseCases.Queries.GetCameraByName
{
    internal class GetCameraByNameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetCameraByNameRequest, IEnumerable<Camera>>
    {
        public async Task<IEnumerable<Camera>> Handle(GetCameraByNameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.name.ToLower();

            return await unitOfWork.CameraRepository
                .ListAsync(a => a.Name.ToLower() == searchKeyword ||
                                a.Name.ToLower().StartsWith(searchKeyword) ||
                                a.Name.ToLower().Contains(searchKeyword), cancellationToken);
        }
    }
}
