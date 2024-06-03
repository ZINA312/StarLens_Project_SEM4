using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Persistance.Postgres.Repository
{ 
    public class FakeSubscriptionRepository : IRepository<Subscription>
    {
        private List<Subscription> _subscriptions;

        public FakeSubscriptionRepository()
        {
            _subscriptions = new List<Subscription>();
        }

        public Task AddAsync(Subscription entity, CancellationToken cancellationToken = default)
        {
            _subscriptions.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Subscription entity, CancellationToken cancellationToken = default)
        {
            _subscriptions.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<Subscription> FirstOrDefaultAsync(Expression<Func<Subscription, bool>> filter, CancellationToken cancellationToken = default)
        {
            Subscription subscription = _subscriptions.FirstOrDefault(filter.Compile());
            return Task.FromResult(subscription);
        }

        public Task<Subscription> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<Subscription, object>>[] includesProperties)
        {
            Subscription subscription = _subscriptions.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(subscription);
        }

        public Task<IReadOnlyList<Subscription>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<Subscription> subscriptionList = _subscriptions;
            return Task.FromResult(subscriptionList);
        }

        public Task<IReadOnlyList<Subscription>> ListAsync(Expression<Func<Subscription, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Subscription, object>>[] includesProperties)
        {
            List<Subscription> filteredSubscriptionss = _subscriptions.Where(filter.Compile()).ToList();
            IReadOnlyList<Subscription> filteredSubscriptionsList = filteredSubscriptionss;
            return Task.FromResult(filteredSubscriptionsList);
        }

        public Task UpdateAsync(Subscription entity, CancellationToken cancellationToken = default)
        {
            // Perform any necessary update operations
            return Task.CompletedTask;
        }
    }
}
