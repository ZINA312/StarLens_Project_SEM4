using StarLens.Applicationn.UserUseCases.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TopicUseCases.Commands.AddTopic
{
    internal class AddTopicHandler : IRequestHandler<AddTopicRequest, Topic>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddTopicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Topic> Handle(AddTopicRequest request, CancellationToken cancellationToken)
        {
            Topic newTopic = new Topic(request.userId, request.title, request.text);
            await _unitOfWork.TopicRepository.AddAsync(newTopic, cancellationToken);
            return newTopic;
        }
    }
}
