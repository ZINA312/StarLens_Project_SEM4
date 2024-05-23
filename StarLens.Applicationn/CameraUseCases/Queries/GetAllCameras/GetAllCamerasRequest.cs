
namespace StarLens.Applicationn.CameraUseCases.Queries.GetAllCameras
{
    public sealed record GetAllCamerasRequest() : IRequest<IEnumerable<Camera>>
    { }
}
