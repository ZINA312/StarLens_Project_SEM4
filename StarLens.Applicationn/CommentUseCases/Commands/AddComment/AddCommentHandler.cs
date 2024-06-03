using StarLens.Applicationn.UserUseCases.Commands.AddUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CommentUseCases.Commands.AddComment
{
    internal class AddCommentHandler : IRequestHandler<AddCommentRequest, Comment>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Comment> Handle(AddCommentRequest request, CancellationToken cancellationToken)
        {
            Comment newComment = new Comment(request.id, request.text);
            await _unitOfWork.CommentRepository.AddAsync(newComment, cancellationToken);
            return newComment;
        }
    }
}
