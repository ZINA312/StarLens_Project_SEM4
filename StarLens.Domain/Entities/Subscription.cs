namespace StarLens.Domain.Entities
{
    public class Subscription : Entity
    {
        public Guid User { get; set; }
        public Guid SubscribedUser { get; set; }
    }
}
