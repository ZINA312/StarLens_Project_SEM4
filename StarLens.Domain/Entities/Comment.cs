namespace StarLens.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(int userid, string text) 
        { 
            UserId = userid;
            Text = text;
            Date = DateTime.Now.ToString("d");
        }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<int> LikedByUsersId { get; set; } = [];

    }
}
