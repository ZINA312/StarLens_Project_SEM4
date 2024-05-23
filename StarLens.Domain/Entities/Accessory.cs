namespace StarLens.Domain.Entities
{
    public class Accessory : Entity
    {
        public Accessory(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
