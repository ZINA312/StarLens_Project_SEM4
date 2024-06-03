using StarLens.Applicationn.CameraUseCases.Queries.GetCameraById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TelescopeUseCases.Queries.GetTelescopeById
{
    internal class GetTelescopeByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetTelescopeByIdRequest, IEnumerable<Telescope>>
    {
        public async Task<IEnumerable<Telescope>> Handle(GetTelescopeByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.TelescopeRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
   
}
