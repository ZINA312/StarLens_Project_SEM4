using MediatR;
using StarLens.Applicationn.CommentUseCases.Queries.GetCommentById;
using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CommentUseCases.Queries.GetCommentsByManyIds
{
    internal class GetCommentsByManyIdsHandler(IUnitOfWork unitOfWork, IMediator mediator) :
        IRequestHandler<GetCommentsByManyIdsRequest, IEnumerable<Comment>>
    {
        public async Task<IEnumerable<Comment>> Handle(GetCommentsByManyIdsRequest request, CancellationToken cancellationToken)
        {
            var commentIds = request.Ids.ToList();
            var comments = await unitOfWork.CommentRepository.ListAsync(comment => commentIds.Contains(comment.Id), cancellationToken);
            var userIds = comments.Select(comment => comment.UserId).Distinct().ToList();
            var users = new List<User>();
            foreach (var userId in userIds)
            {
                var user = await mediator.Send(new GetUserByIdRequest(userId));
                users.Add(user);
            }
            foreach (var comment in comments)
            {
                comment.User = users.FirstOrDefault(user => user.Id == comment.UserId);
            }
            return comments;
        }
    }
}
