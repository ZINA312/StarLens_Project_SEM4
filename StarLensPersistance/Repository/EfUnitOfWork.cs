using StarLens.Persistance.Postgres.Data;

namespace StarLens.Persistance.Postgres.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Accessory>> _accessoryRepository;
        private readonly Lazy<IRepository<Camera>> _cameraRepository;
        private readonly Lazy<IRepository<Comment>> _commentRepository;
        private readonly Lazy<IRepository<Equipment>> _equipmentRepository;
        private readonly Lazy<IRepository<Filter>> _filterRepository;
        private readonly Lazy<IRepository<Like>> _likeRepository;
        private readonly Lazy<IRepository<Mount>> _mountRepository;
        private readonly Lazy<IRepository<Publication>> _publicationRepository;
        private readonly Lazy<IRepository<Session>> _sessionRepository;
        private readonly Lazy<IRepository<Subscription>> _subscriptionRepository;
        private readonly Lazy<IRepository<TechCard>> _techCardRepository;
        private readonly Lazy<IRepository<Telescope>> _telescopeRepository;
        private readonly Lazy<IRepository<Topic>> _topicRepository;
        private readonly Lazy<IRepository<User>> _userRepository;


        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _accessoryRepository = new Lazy<IRepository<Accessory>>(() =>
            new EfRepository<Accessory>(context));
            _cameraRepository = new Lazy<IRepository<Camera>>(() =>
            new EfRepository<Camera>(context)); 
            _commentRepository = new Lazy<IRepository<Comment>>(() =>
            new EfRepository<Comment>(context));
            _equipmentRepository = new Lazy<IRepository<Equipment>>(() =>
            new EfRepository<Equipment>(context));
            _filterRepository = new Lazy<IRepository<Filter>>(() =>
            new EfRepository<Filter>(context));
            _likeRepository = new Lazy<IRepository<Like>>(() =>
            new EfRepository<Like>(context));
            _mountRepository = new Lazy<IRepository<Mount>>(() =>
            new EfRepository<Mount>(context));
            _publicationRepository = new Lazy<IRepository<Publication>>(() =>
            new EfRepository<Publication>(context));
            _sessionRepository = new Lazy<IRepository<Session>>(() =>
            new EfRepository<Session>(context));
            _subscriptionRepository = new Lazy<IRepository<Subscription>>(() =>
            new EfRepository<Subscription>(context));
            _techCardRepository = new Lazy<IRepository<TechCard>>(() =>
            new EfRepository<TechCard>(context));
            _telescopeRepository = new Lazy<IRepository<Telescope>>(() =>
            new EfRepository<Telescope>(context));
            _topicRepository = new Lazy<IRepository<Topic>>(() =>
            new EfRepository<Topic>(context));
            _userRepository = new Lazy<IRepository<User>>(() =>
            new EfRepository<User>(context));
        }

        public IRepository<Accessory> AccessoryRepository => _accessoryRepository.Value;
        public IRepository<Camera> CameraRepository => _cameraRepository.Value;
        public IRepository<Comment> CommentRepository => _commentRepository.Value;
        public IRepository<Equipment> EquipmentRepository => _equipmentRepository.Value;
        public IRepository<Filter> FilterRepository => _filterRepository.Value;
        public IRepository<Like> LikeRepository => _likeRepository.Value;
        public IRepository<Mount> MountRepository => _mountRepository.Value;
        public IRepository<Publication> PublicationRepository => _publicationRepository.Value;
        public IRepository<Session> SessionRepository => _sessionRepository.Value;
        public IRepository<Subscription> SubscriptionRepository => _subscriptionRepository.Value;
        public IRepository<TechCard> TechCardRepository => _techCardRepository.Value;
        public IRepository<Telescope> TelescopeRepository => _telescopeRepository.Value;
        public IRepository<Topic> TopicRepository => _topicRepository.Value;
        public IRepository<User> UserRepository => _userRepository.Value;

        public async Task CreateDataBaseAsync() =>
         await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
         await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
         await _context.SaveChangesAsync();
    }
}