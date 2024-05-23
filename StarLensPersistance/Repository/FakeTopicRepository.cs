
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeTopicRepository : IRepository<Topic>
    {
        private List<Topic> _topics;

        public FakeTopicRepository()
        {
            _topics = new List<Topic>();
        }

        public Task AddAsync(Topic entity, CancellationToken cancellationToken = default)
        {
            _topics.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Topic entity, CancellationToken cancellationToken = default)
        {
            _topics.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Topic> FirstOrDefaultAsync(Expression<Func<Topic, bool>> filter, CancellationToken cancellationToken = default)
        {
            Topic topic = _topics.FirstOrDefault(filter.Compile());
            return Task.FromResult(topic);
        }

        public Task<Topic> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Topic, object>>[] includesProperties)
        {
            Topic topic = _topics.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(topic);
        }

        public Task<IReadOnlyList<Topic>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Topic> topicList = _topics;
            return Task.FromResult(topicList);
        }

        public Task<IReadOnlyList<Topic>> ListAsync(Expression<Func<Topic, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Topic, object>>[] includesProperties)
        {
            List<Topic> filteredTopics = _topics.Where(filter.Compile()).ToList();
            IReadOnlyList<Topic> filteredTopicsList = filteredTopics;
            return Task.FromResult(filteredTopicsList);
        }

        public Task UpdateAsync(Topic entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
