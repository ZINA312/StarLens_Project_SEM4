using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.PublicationUseCases.Commands.AddPublication
{
    internal class AddPublicationHandler : IRequestHandler<AddPublicationRequest, Publication>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddPublicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Publication> Handle(AddPublicationRequest request, CancellationToken cancellationToken)
        {
            await _unitOfWork.PublicationRepository.AddAsync(request.publication, cancellationToken);
            return request.publication;
        }
    }
}
