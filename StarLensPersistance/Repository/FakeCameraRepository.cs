
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeCameraRepository : IRepository<Camera>
    {
        private List<Camera> _cameras;

        public FakeCameraRepository()
        {
            _cameras = new List<Camera>
            {
                new Camera("Camera 1", "Type 1", 1.0f, 2.0f, 3.0f, true, 80),
                new Camera("Camera 2", "Type 2", 1.5f, 2.5f, 3.5f, false, 70),
                new Camera("Camera 3", "Type 3", 1.2f, 2.2f, 3.2f, true, 90)
            };
        }

        public Task AddAsync(Camera entity, CancellationToken cancellationToken = default)
        {
            _cameras.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Camera entity, CancellationToken cancellationToken = default)
        {
            _cameras.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Camera> FirstOrDefaultAsync(Expression<Func<Camera, bool>> filter, CancellationToken cancellationToken = default)
        {
            Camera techCard = _cameras.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<Camera> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<Camera, object>>[] includesProperties)
        {
            Camera techCard = _cameras.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<Camera>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Camera> cameraaList = _cameras;
            return Task.FromResult(cameraaList);
        }

        public Task<IReadOnlyList<Camera>> ListAsync(Expression<Func<Camera, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Camera, object>>[] includesProperties)
        {
            List<Camera> filteredCameras = _cameras.Where(filter.Compile()).ToList();
            IReadOnlyList<Camera> filteredCamerasList = filteredCameras;
            return Task.FromResult(filteredCamerasList);
        }

        public Task UpdateAsync(Camera entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
