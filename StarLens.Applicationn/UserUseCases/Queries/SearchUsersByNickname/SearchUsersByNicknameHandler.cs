using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.UserUseCases.Queries.SearchUsersByNickname
{
    internal class SearchUsersByNicknameHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<SearchUsersByNicknameRequest,IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle(SearchUsersByNicknameRequest request, CancellationToken cancellationToken)
        {
            string searchKeyword = request.nickname.ToLower();

            return await unitOfWork.UserRepository
                .ListAsync(a => a.UserName.ToLower() == searchKeyword ||
                        a.UserName.ToLower().StartsWith(searchKeyword) ||
                        a.UserName.ToLower().Contains(searchKeyword), cancellationToken); ;
        }
    }
}
