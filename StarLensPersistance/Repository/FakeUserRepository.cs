
using System.Linq.Expressions;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeUserRepository : IRepository<User>
    {
        List<User> _users;
        public FakeUserRepository()
        {
            _users = new List<User>();

            User user1 = new User("user1", "password1", "user1@example.com");
            user1.Status = 0;

            User user2 = new User("user2", "password2", "user2@example.com");
            user2.Status = 1;

            User user3 = new User("user3", "password3", "user3@example.com");
            user3.Status = 2;

            _users.Add(user1);
            _users.Add(user2);
            _users.Add(user3);
        }

        public Task AddAsync(User entity, CancellationToken cancellationToken = default)
        {
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            _users.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default)
        {
            User user = _users.FirstOrDefault(filter.Compile());
            return Task.FromResult(user);
        }

        public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default, params Expression<Func<User, object>>[]? includesProperties)
        {
            User user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<IReadOnlyList<User>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IReadOnlyList<User> userList = _users;
            return Task.FromResult(userList);
        }

        public Task<IReadOnlyList<User>> ListAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<User, object>>[]? includesProperties)
        {
            List<User> filteredUsers = _users.Where(filter.Compile()).ToList();
            IReadOnlyList<User> filteredUserList = filteredUsers;
            return Task.FromResult(filteredUserList);
        }

        public Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
