
namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAllAccessories
{
    public sealed record GetAllAccessoriesRequest() : IRequest<IEnumerable<Accessory>>
    { }
}
