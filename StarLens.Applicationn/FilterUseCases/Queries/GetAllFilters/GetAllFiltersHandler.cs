using StarLens.Applicationn.CameraUseCases.Queries.GetAllCameras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.FilterUseCases.Queries.GetAllFilters
{
    internal class GetAllFiltersHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetAllFiltersRequest, IEnumerable<Filter>>
    {
        public async Task<IEnumerable<Filter>> Handle(GetAllFiltersRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.FilterRepository.ListAllAsync(cancellationToken);
        }
    }
}
