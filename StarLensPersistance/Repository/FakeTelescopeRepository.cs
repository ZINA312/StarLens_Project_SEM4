
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeTelescopeRepository : IRepository<Telescope>
    {
        private List<Telescope> _telescopes;

        public FakeTelescopeRepository()
        {
            _telescopes = new List<Telescope>()
            {
                new Telescope("Telescope 1", "Type 1", 2000f, 200f),
                new Telescope("Telescope 2", "Type 2", 2000f, 200f),
                new Telescope("Telescope 3", "Type 3", 2000f, 200f),
            };
        }

        public Task AddAsync(Telescope entity, CancellationToken cancellationToken = default)
        {
            _telescopes.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Telescope entity, CancellationToken cancellationToken = default)
        {
            _telescopes.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Telescope> FirstOrDefaultAsync(Expression<Func<Telescope, bool>> filter, CancellationToken cancellationToken = default)
        {
            Telescope techCard = _telescopes.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<Telescope> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Telescope, object>>[] includesProperties)
        {
            Telescope techCard = _telescopes.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<Telescope>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Telescope> telescopeList = _telescopes;
            return Task.FromResult(telescopeList);
        }

        public Task<IReadOnlyList<Telescope>> ListAsync(Expression<Func<Telescope, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Telescope, object>>[] includesProperties)
        {
            List<Telescope> filteredTelescopes = _telescopes.Where(filter.Compile()).ToList();
            IReadOnlyList<Telescope> filteredTelescopesList = filteredTelescopes;
            return Task.FromResult(filteredTelescopesList);
        }

        public Task UpdateAsync(Telescope entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
