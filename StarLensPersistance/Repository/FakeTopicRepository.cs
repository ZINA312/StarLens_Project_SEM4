
using StarLens.Domain.Entities;
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeTopicRepository : IRepository<Topic>
    {
        private List<Topic> _topics;
        private int id = 1;
        public FakeTopicRepository()
        {
            _topics = new List<Topic>();
            var topic1 = new Topic(1, "Title 1", "Text 1");
            topic1.Id = id;
            id++;
            topic1.AddCommentId(1);
            topic1.AddCommentId(2);
            topic1.AddCommentId(3);
            _topics.Add(topic1);
            var topic2 = new Topic(1, "Title 2", "Text 2");
            topic2.Id = id;
            id++;
            _topics.Add(topic2);
            var topic3 = new Topic(1, "Title 3", "Text 3");
            topic3.Id = id;
            id++;
            _topics.Add(topic3);
        }

        public Task AddAsync(Topic entity, CancellationToken cancellationToken = default)
        {
            entity.Id = id;
            id++;
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

        public Task<Topic> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Topic, object>>[] includesProperties)
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

        public Task UpdateAsync(Topic topic, CancellationToken cancellationToken = default)
        {
            var existingTopicIndex = _topics.FindIndex(t => t.Id == topic.Id);
            if (existingTopicIndex >= 0)
            {
                _topics[existingTopicIndex] = topic;
            }
            return Task.CompletedTask;
        }
    }
}
