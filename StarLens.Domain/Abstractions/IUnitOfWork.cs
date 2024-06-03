using StarLens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Camera> CameraRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        IRepository<Filter> FilterRepository { get; }
        IRepository<Mount> MountRepository { get; }
        IRepository<Publication> PublicationRepository { get; }
        IRepository<Session> SessionRepository { get; }
        IRepository<Subscription> SubscriptionRepository { get; }
        IRepository<TechCard> TechCardRepository { get; }
        IRepository<Telescope> TelescopeRepository { get; }
        IRepository<Topic> TopicRepository { get; }
        IRepository<User> UserRepository { get; }
        public Task SaveAllAsync();
        public Task DeleteDataBaseAsync();
        public Task CreateDataBaseAsync();
    }
}
