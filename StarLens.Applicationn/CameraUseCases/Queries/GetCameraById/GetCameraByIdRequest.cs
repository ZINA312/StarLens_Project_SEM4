using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CameraUseCases.Queries.GetCameraById
{
    public sealed record GetCameraByIdRequest(int Id) : IRequest<IEnumerable<Camera>>
    { }
}
