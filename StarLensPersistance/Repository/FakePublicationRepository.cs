
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakePublicationRepository : IRepository<Publication>
    {
        private List<Publication> _publications;

        public FakePublicationRepository()
        {
            _publications = new List<Publication>();
        }

        public Task AddAsync(Publication entity, CancellationToken cancellationToken = default)
        {
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

        public Task<Publication> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Publication, object>>[] includesProperties)
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

