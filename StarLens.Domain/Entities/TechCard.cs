namespace StarLens.Domain.Entities
{
    public class TechCard : Entity
    {
        public Equipment? Equipment { get; set; }
        public List<Session> Sessions { get; set; } = [];
    }
}
