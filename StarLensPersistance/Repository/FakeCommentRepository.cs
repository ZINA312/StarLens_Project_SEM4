
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeCommentRepository : IRepository<Comment>
    {
        private List<Comment> _comments;
        private int id = 1;
        public FakeCommentRepository()
        {
            _comments = new List<Comment>();
            var comment = new Comment(1, "Comment 1");
            comment.Id = id;
            id++;
            _comments.Add(comment);
            comment = new Comment(2, "Comment 2");
            comment.Id = id;
            id++;
            _comments.Add(comment);
            comment = new Comment(3, "Comment 3");
            comment.Id = id;
            id++;
            _comments.Add(comment);
        }

        public Task AddAsync(Comment entity, CancellationToken cancellationToken = default)
        {
            entity.Id = id;
            id++;
            _comments.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Comment entity, CancellationToken cancellationToken = default)
        {
            _comments.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Comment> FirstOrDefaultAsync(Expression<Func<Comment, bool>> filter, CancellationToken cancellationToken = default)
        {
            Comment publication = _comments.FirstOrDefault(filter.Compile());
            return Task.FromResult(publication);
        }

        public Task<Comment> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Comment, object>>[] includesProperties)
        {
            Comment like = _comments.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(like);
        }

        public Task<IReadOnlyList<Comment>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Comment> commentList = _comments;
            return Task.FromResult(commentList);
        }

        public Task<IReadOnlyList<Comment>> ListAsync(Expression<Func<Comment, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Comment, object>>[] includesProperties)
        {
            List<Comment> filteredLikes = _comments.Where(filter.Compile()).ToList();
            IReadOnlyList<Comment> filteredLikeList = filteredLikes;
            return Task.FromResult(filteredLikeList);
        }

        public Task UpdateAsync(Comment entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
