
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeFilterRepository : IRepository<Filter>
    {
        private List<Filter> _filters;

        public FakeFilterRepository()
        {
            _filters = new List<Filter>();
        }

        public Task AddAsync(Filter entity, CancellationToken cancellationToken = default)
        {
            _filters.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Filter entity, CancellationToken cancellationToken = default)
        {
            _filters.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Filter> FirstOrDefaultAsync(Expression<Func<Filter, bool>> filter, CancellationToken cancellationToken = default)
        {
            Filter techCard = _filters.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<Filter> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Filter, object>>[] includesProperties)
        {
            Filter techCard = _filters.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<Filter>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Filter> filterList = _filters;
            return Task.FromResult(filterList);
        }

        public Task<IReadOnlyList<Filter>> ListAsync(Expression<Func<Filter, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Filter, object>>[] includesProperties)
        {
            List<Filter> filteredFilters = _filters.Where(filter.Compile()).ToList();
            IReadOnlyList<Filter> filteredFiltersList = filteredFilters;
            return Task.FromResult(filteredFiltersList);
        }

        public Task UpdateAsync(Filter entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
