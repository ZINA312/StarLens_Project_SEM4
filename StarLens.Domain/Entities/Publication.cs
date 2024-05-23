namespace StarLens.Domain.Entities
{
    public class Publication : Entity
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Guid> LikedByUsersId { get; set; } = [];
        public List<Guid> Comments { get; set; } = [];
        public TechCard? TechInfo { get; set; }
        public string Date { get; set; } = string.Empty;
    }
}
