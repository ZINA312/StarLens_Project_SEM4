namespace StarLens.Domain.Entities
{
    public class Filter : Entity
    {
        public string Name { get; set; } = string.Empty;
        public float Size { get; set; } = 0;
    }
}
