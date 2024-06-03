using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CommentUseCases.Queries.GetCommentById
{
    internal class GetCommentByIdHandler(IUnitOfWork unitOfWork) :
        IRequestHandler<GetCommentByIdRequest, Comment>
    {
        public async Task<Comment> Handle(GetCommentByIdRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.CommentRepository.FirstOrDefaultAsync(t => t.Id.Equals(request.Id), cancellationToken);
        }
    }
}
