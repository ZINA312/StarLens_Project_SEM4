namespace StarLens.Domain.Entities
{
    public class Publication : Entity
    {
        public Publication(int userid,string title, string description, TechCard? techCard) 
        {
            UserId = userid;
            Title = title;
            Description = description;
            TechInfo = techCard;
            Date = DateTime.Now.ToString("d");
        }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<int> LikedByUsersId { get; set; } = [];
        public List<int> Comments { get; set; } = [];
        public TechCard? TechInfo { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}
