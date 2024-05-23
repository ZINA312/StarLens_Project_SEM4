namespace StarLens.Domain.Entities
{
    public class Topic : Entity
    {
        public Guid CreatorId { get; set; }
        public User? Creator { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = [];
    }
}
