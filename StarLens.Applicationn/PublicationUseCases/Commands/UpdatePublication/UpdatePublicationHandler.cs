using StarLens.Applicationn.TopicUseCases.Commands.UpdateTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.PublicationUseCases.Commands.UpdatePublication
{
    internal class UpdatePublicationHandler : IRequestHandler<UpdatePublicationRequest, Publication>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePublicationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Publication> Handle(UpdatePublicationRequest request, CancellationToken cancellationToken)
        {

            await _unitOfWork.PublicationRepository.UpdateAsync(request.publication, cancellationToken);
            return request.publication;
        }
    }
}
