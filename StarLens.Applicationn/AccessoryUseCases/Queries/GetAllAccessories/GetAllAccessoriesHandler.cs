using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAllAccessories
{
    internal class GetAllAccessoriesHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllAccessoriesRequest, IEnumerable<Accessory>>
    {
        public async Task<IEnumerable<Accessory>> Handle(GetAllAccessoriesRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.AccessoryRepository.ListAllAsync(cancellationToken);
        }
    }
}
