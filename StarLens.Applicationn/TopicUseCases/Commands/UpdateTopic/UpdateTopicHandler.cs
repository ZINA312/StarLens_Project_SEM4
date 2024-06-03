using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TopicUseCases.Commands.UpdateTopic
{
    internal class UpdateTopicHandler : IRequestHandler<UpdateTopicRequest, Topic>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateTopicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Topic> Handle(UpdateTopicRequest request, CancellationToken cancellationToken) {
        
            await _unitOfWork.TopicRepository.UpdateAsync(request.topic, cancellationToken);
            return request.topic;
        }
    }
}
