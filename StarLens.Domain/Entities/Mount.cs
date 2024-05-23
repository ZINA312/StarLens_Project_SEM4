namespace StarLens.Domain.Entities
{
    public class Mount : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public float LoadCapacity { get; set; } = 0;
    }
}
