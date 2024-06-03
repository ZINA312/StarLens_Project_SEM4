using StarLens.Applicationn.CameraUseCases.Queries.GetCameraByName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.FilterUseCases.Queries.GetFilterByName
{
    internal class GetFilterByNameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetFilterByNameRequest, IEnumerable<Filter>>
    {
        public async Task<IEnumerable<Filter>> Handle(GetFilterByNameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.name.ToLower();

            return await unitOfWork.FilterRepository
                .ListAsync(a => a.Name.ToLower() == searchKeyword ||
                                a.Name.ToLower().StartsWith(searchKeyword) ||
                                a.Name.ToLower().Contains(searchKeyword), cancellationToken);
        }
    }
}
