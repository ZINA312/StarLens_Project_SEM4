using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using StarLens.Applicationn.UserUseCases.Queries.SearchUsersByNickname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TopicUseCases.Queries.GetTopicsByTitle
{
    internal class GetTopicsByTitleHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetTopicsByTitleRequest, IEnumerable<Topic>>
    {
        public async Task<IEnumerable<Topic>> Handle(GetTopicsByTitleRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.title.ToLower();

            return await unitOfWork.TopicRepository
                .ListAsync(a => a.Title.ToLower() == searchKeyword ||
                        a.Title.ToLower().StartsWith(searchKeyword) ||
                        a.Title.ToLower().Contains(searchKeyword), cancellationToken); ;
        }
    }
}
