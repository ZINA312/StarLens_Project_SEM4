using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarLens.Persistance.Postgres.Data;

namespace StarLens.Persistance.Postgres.Repository
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly FakeUserRepository _userRepository;
        private readonly FakeCameraRepository _cameraRepository;
        private readonly FakeCommentRepository _commentRepository;
        private readonly FakeFilterRepository _filterRepository;
        private readonly FakeMountRepository _mountRepository;
        private readonly FakePublicationRepository _publicationRepository;
        private readonly FakeSessionRepository _sessionRepository;
        private readonly FakeSubscriptionRepository _subscriptionRepository;
        private readonly FakeTechCardRepository _techCardRepository;
        private readonly FakeTelescopeRepository _telescopeRepository;
        private readonly FakeTopicRepository _topicRepository;
        public FakeUnitOfWork()
        {
            _userRepository = new FakeUserRepository();
            _cameraRepository = new FakeCameraRepository(); 
            _commentRepository = new FakeCommentRepository();
            _filterRepository = new FakeFilterRepository();
            _mountRepository = new FakeMountRepository();
            _publicationRepository = new FakePublicationRepository();
            _sessionRepository = new FakeSessionRepository();
            _subscriptionRepository = new FakeSubscriptionRepository();
            _techCardRepository = new FakeTechCardRepository();
            _topicRepository = new FakeTopicRepository();
            _telescopeRepository = new FakeTelescopeRepository();
        }
        public IRepository<User> UserRepository => _userRepository;
        public IRepository<Camera> CameraRepository => _cameraRepository;
        public IRepository<Comment> CommentRepository => _commentRepository;
        public IRepository<Filter> FilterRepository => _filterRepository;
        public IRepository<Mount> MountRepository => _mountRepository;
        public IRepository<Publication> PublicationRepository => _publicationRepository;
        public IRepository<Session> SessionRepository => _sessionRepository;
        public IRepository<Subscription> SubscriptionRepository => _subscriptionRepository;
        public IRepository<TechCard> TechCardRepository => _techCardRepository;
        public IRepository<Telescope> TelescopeRepository => _telescopeRepository;
        public IRepository<Topic> TopicRepository => _topicRepository;

        public Task CreateDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteDataBaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
