
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeTechCardRepository : IRepository<TechCard>
    {
        private List<TechCard> _techcards;

        public FakeTechCardRepository()
        {
            _techcards = new List<TechCard>();
        }

        public Task AddAsync(TechCard entity, CancellationToken cancellationToken = default)
        {
            _techcards.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TechCard entity, CancellationToken cancellationToken = default)
        {
            _techcards.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<TechCard> FirstOrDefaultAsync(Expression<Func<TechCard, bool>> filter, CancellationToken cancellationToken = default)
        {
            TechCard techCard = _techcards.FirstOrDefault(filter.Compile());
            return Task.FromResult(techCard);
        }

        public Task<TechCard> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<TechCard, object>>[] includesProperties)
        {
            TechCard techCard = _techcards.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(techCard);
        }

        public Task<IReadOnlyList<TechCard>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<TechCard> techCardList = _techcards;
            return Task.FromResult(techCardList);
        }

        public Task<IReadOnlyList<TechCard>> ListAsync(Expression<Func<TechCard, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<TechCard, object>>[] includesProperties)
        {
            List<TechCard> filteredTechCards = _techcards.Where(filter.Compile()).ToList();
            IReadOnlyList<TechCard> filteredTechCardsList = filteredTechCards;
            return Task.FromResult(filteredTechCardsList);
        }

        public Task UpdateAsync(TechCard entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
