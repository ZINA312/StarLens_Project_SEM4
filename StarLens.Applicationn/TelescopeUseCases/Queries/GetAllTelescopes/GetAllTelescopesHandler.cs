using StarLens.Applicationn.CameraUseCases.Queries.GetAllCameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TelescopeUseCases.Queries.GetAllTelescopes
{
    internal class GetAllTelescopesHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllTelescopesRequest, IEnumerable<Telescope>>
    {
        public async Task<IEnumerable<Telescope>> Handle(GetAllTelescopesRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.TelescopeRepository.ListAllAsync(cancellationToken);
        }
    }
}
