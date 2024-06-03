using StarLens.Applicationn.CameraUseCases.Queries.GetCameraByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TelescopeUseCases.Queries.GetTelescopeByName
{
    internal class GetTelescopeByNameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetTelescopeByNameRequest, IEnumerable<Telescope>>
    {
        public async Task<IEnumerable<Telescope>> Handle(GetTelescopeByNameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.name.ToLower();

            return await unitOfWork.TelescopeRepository
                .ListAsync(a => a.Name.ToLower() == searchKeyword ||
                                a.Name.ToLower().StartsWith(searchKeyword) ||
                                a.Name.ToLower().Contains(searchKeyword), cancellationToken);
        }
    }
}
