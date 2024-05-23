
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeCommentRepository : IRepository<Comment>
    {
        private List<Comment> _comments;

        public FakeCommentRepository()
        {
            _comments = new List<Comment>();
        }

        public Task AddAsync(Comment entity, CancellationToken cancellationToken = default)
        {
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

        public Task<Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Comment, object>>[] includesProperties)
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
