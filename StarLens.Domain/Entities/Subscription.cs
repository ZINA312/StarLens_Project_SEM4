namespace StarLens.Domain.Entities
{
    public class Subscription : Entity
    {
        public Subscription(int currentUserId, int subscribedUserId) 
        {
            User = currentUserId;
            SubscribedUser = subscribedUserId;
        }
        public int User { get; set; }
        public int SubscribedUser { get; set; }
    }
}
