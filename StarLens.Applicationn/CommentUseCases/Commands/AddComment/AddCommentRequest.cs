using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.CommentUseCases.Commands.AddComment
{
    public sealed record AddCommentRequest(int id, string text) : IRequest<Comment>
    { }
}
