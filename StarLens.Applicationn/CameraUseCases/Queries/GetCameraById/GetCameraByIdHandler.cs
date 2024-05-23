using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CameraUseCases.Queries.GetCameraById
{
    internal class GetCameraByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetCameraByIdRequest, IEnumerable<Camera>>
    {
        public async Task<IEnumerable<Camera>> Handle(GetCameraByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.CameraRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
