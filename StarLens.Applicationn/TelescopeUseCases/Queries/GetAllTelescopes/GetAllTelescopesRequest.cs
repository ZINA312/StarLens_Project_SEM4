
namespace StarLens.Applicationn.TelescopeUseCases.Queries.GetAllTelescopes
{
    public sealed record GetAllTelescopesRequest() : IRequest<IEnumerable<Telescope>>
    { }
}
