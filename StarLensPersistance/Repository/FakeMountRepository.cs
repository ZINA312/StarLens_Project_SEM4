
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeMountRepository : IRepository<Mount>
    {
        private List<Mount> _mount;

        public FakeMountRepository()
        {
            _mount = new List<Mount>();
        }

        public Task AddAsync(Mount entity, CancellationToken cancellationToken = default)
        {
            _mount.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Mount entity, CancellationToken cancellationToken = default)
        {
            _mount.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Mount> FirstOrDefaultAsync(Expression<Func<Mount, bool>> filter, CancellationToken cancellationToken = default)
        {
            Mount techCard = _mount.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<Mount> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Mount, object>>[] includesProperties)
        {
            Mount techCard = _mount.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<Mount>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Mount> mountList = _mount;
            return Task.FromResult(mountList);
        }

        public Task<IReadOnlyList<Mount>> ListAsync(Expression<Func<Mount, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Mount, object>>[] includesProperties)
        {
            List<Mount> filteredMounts = _mount.Where(filter.Compile()).ToList();
            IReadOnlyList<Mount> filteredMountsList = filteredMounts;
            return Task.FromResult(filteredMountsList);
        }

        public Task UpdateAsync(Mount entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
