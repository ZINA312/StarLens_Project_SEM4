
namespace StarLens.Applicationn.CameraUseCases.Queries.GetCameraByName
{
    public sealed record GetCameraByNameRequest(string name) : IRequest<IEnumerable<Camera>>
    { }
}
