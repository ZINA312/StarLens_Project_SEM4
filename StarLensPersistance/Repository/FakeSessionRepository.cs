
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeSessionRepository : IRepository<Session>
    {
        private List<Session> _sessions;

        public FakeSessionRepository()
        {
            _sessions = new List<Session>();
        }

        public Task AddAsync(Session entity, CancellationToken cancellationToken = default)
        {
            _sessions.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Session entity, CancellationToken cancellationToken = default)
        {
            _sessions.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Session> FirstOrDefaultAsync(Expression<Func<Session, bool>> filter, CancellationToken cancellationToken = default)
        {
            Session session = _sessions.FirstOrDefault(filter.Compile());
            return Task.FromResult(session);
        }

        public Task<Session> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Session, object>>[] includesProperties)
        {
            Session session = _sessions.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(session);
        }

        public Task<IReadOnlyList<Session>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Session> sessionList = _sessions;
            return Task.FromResult(sessionList);
        }

        public Task<IReadOnlyList<Session>> ListAsync(Expression<Func<Session, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Session, object>>[] includesProperties)
        {
            List<Session> filteredSessions = _sessions.Where(filter.Compile()).ToList();
            IReadOnlyList<Session> filteredSessionsList = filteredSessions;
            return Task.FromResult(filteredSessionsList);
        }

        public Task UpdateAsync(Session entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
