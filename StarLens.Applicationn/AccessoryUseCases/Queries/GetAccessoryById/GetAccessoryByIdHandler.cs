using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.AccessoryUseCases.Queries.GetAccessoryById
{
    internal class GetAccessoryByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAccessoryByIdRequest, IEnumerable<Accessory>>
    {
        public async Task<IEnumerable<Accessory>> Handle(GetAccessoryByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.AccessoryRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
