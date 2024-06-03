namespace StarLens.Domain.Entities
{
    public class Filter : Entity
    {
        public Filter(string name, float size) 
        {
            Name = name;
            Size = size;
        }
        public string Name { get; set; } = string.Empty;
        public float Size { get; set; } = 0;
    }
}
