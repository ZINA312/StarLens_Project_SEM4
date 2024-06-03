using StarLens.Applicationn.CameraUseCases.Queries.GetCameraByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.MountUseCases.Queries.GetMountByName
{
    internal class GetMountByNameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetMountByNameRequest, IEnumerable<Mount>>
    {
        public async Task<IEnumerable<Mount>> Handle(GetMountByNameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.name.ToLower();

            return await unitOfWork.MountRepository
                .ListAsync(a => a.Name.ToLower() == searchKeyword ||
                                a.Name.ToLower().StartsWith(searchKeyword) ||
                                a.Name.ToLower().Contains(searchKeyword), cancellationToken);
        }
    }
}
