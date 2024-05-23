namespace StarLens.Domain.Entities
{
    public class User : Entity
    {
        public User(string nickname, string password, string email) 
        {
            UserName = nickname;
            Password = password;
            Email = email;
        }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
        public List<Subscription> Subscriptions { get; set; } = [];
        public List<Publication> Publications { get; set; } = [];
        public List<Topic> Topics { get; set; } = [];
    }
}
