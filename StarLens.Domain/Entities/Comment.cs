namespace StarLens.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(Guid userid, string text) 
        { 
            UserId = userid;
            Text = text;
            Date = DateTime.Now.ToString("d");
        }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<Guid> LikedByUsersId { get; set; } = [];
        public void AddLike(Guid userid)
        {
            LikedByUsersId.Add(userid);
        }
    }
}
