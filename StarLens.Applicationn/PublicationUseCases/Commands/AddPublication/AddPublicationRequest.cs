using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.PublicationUseCases.Commands.AddPublication
{
    public sealed record AddPublicationRequest(Publication publication) : IRequest<Publication>
    { }
}
