using StarLens.

namespace StarLens.Applicationn.CameraUseCases.Queries.GetAllCameras
{
    internal class GetAllCamerasHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllCamerasRequest, IEnumerable<Camera>>
    {
        public async Task<IEnumerable<Camera>> Handle(GetAllCamerasRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.CameraRepository.ListAllAsync(cancellationToken);
        }
    }
}
