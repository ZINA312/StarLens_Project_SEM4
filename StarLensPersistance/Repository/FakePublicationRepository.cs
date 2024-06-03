
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakePublicationRepository : IRepository<Publication>
    {
        private List<Publication> _publications;
        private int _nextId;
        public FakePublicationRepository()
        {
            _publications = new List<Publication>();
            _nextId = 1;
            var publication1 = new Publication(1, "Название публикации 1", "Описание публикации 1", null);
            publication1.Id = _nextId;
            _nextId++;
            var publication2 = new Publication(1, "Название публикации 1", "Описание публикации 2", null);
            publication2.Id = _nextId;
            _nextId++;
            var publication3 = new Publication(1, "Название публикации 1", "Описание публикации 3", null);
            publication3.Id = _nextId;
            _nextId++;

            _publications.Add(publication1);
            _publications.Add(publication2);
            _publications.Add(publication3);
        }

        public Task AddAsync(Publication entity, CancellationToken cancellationToken = default)
        {
            entity.Id = _nextId;
            _nextId++;
            _publications.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Publication entity, CancellationToken cancellationToken = default)
        {
            _publications.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Publication> FirstOrDefaultAsync(Expression<Func<Publication, bool>> filter, CancellationToken cancellationToken = default)
        {
            Publication publication = _publications.FirstOrDefault(filter.Compile());
            return Task.FromResult(publication);
        }

        public Task<Publication> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Publication, object>>[] includesProperties)
        {
            Publication publication = _publications.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(publication);
        }

        public Task<IReadOnlyList<Publication>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Publication> publicationList = _publications;
            return Task.FromResult(publicationList);
        }

        public Task<IReadOnlyList<Publication>> ListAsync(Expression<Func<Publication, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Publication, object>>[] includesProperties)
        {
            List<Publication> filteredPublications = _publications.Where(filter.Compile()).ToList();
            IReadOnlyList<Publication> filteredPublicationList = filteredPublications;
            return Task.FromResult(filteredPublicationList);
        }

        public Task UpdateAsync(Publication entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}

