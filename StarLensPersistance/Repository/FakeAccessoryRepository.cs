using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeAccessoryRepository : IRepository<Accessory>
    {
        private List<Accessory> _accessory;

        public FakeAccessoryRepository()
        {
            _accessory = new List<Accessory>
            {
                new Accessory("Accessory 1", "Description 1"),
                new Accessory("Accessory 2", "Description 2"),
                new Accessory("Accessory 3", "Description 3")
            };
        }

        public Task AddAsync(Accessory entity, CancellationToken cancellationToken = default)
        {
            _accessory.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Accessory entity, CancellationToken cancellationToken = default)
        {
            _accessory.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Accessory> FirstOrDefaultAsync(Expression<Func<Accessory, bool>> filter, CancellationToken cancellationToken = default)
        {
            Accessory techCard = _accessory.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<Accessory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Accessory, object>>[] includesProperties)
        {
            Accessory techCard = _accessory.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<Accessory>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Accessory> accessoryList = _accessory;
            return Task.FromResult(accessoryList);
        }

        public Task<IReadOnlyList<Accessory>> ListAsync(Expression<Func<Accessory, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Accessory, object>>[] includesProperties)
        {
            List<Accessory> filteredAccessories = _accessory.Where(filter.Compile()).ToList();
            IReadOnlyList<Accessory> filteredAccessoryList = filteredAccessories;
            return Task.FromResult(filteredAccessoryList);
        }

        public Task UpdateAsync(Accessory entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
