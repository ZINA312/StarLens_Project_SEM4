
namespace StarLens.Applicationn.MountUseCases.Queries.GetMountByName
{
    public sealed record GetMountByNameRequest(string name) : IRequest<IEnumerable<Mount>>
    { }
}
