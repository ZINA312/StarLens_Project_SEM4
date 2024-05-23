using StarLens.Applicationn.CameraUseCases.Queries.GetCameraById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.FilterUseCases.Queries.GetFilterById
{
    internal class GetFilterByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetFilterByIdRequest, IEnumerable<Filter>>
    {
        public async Task<IEnumerable<Filter>> Handle(GetFilterByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.FilterRepository.ListAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
   
}
