using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.PublicationUseCases.Commands.UpdatePublication
{
    public sealed record UpdatePublicationRequest(Publication publication) : IRequest<Publication>
    { }
}
