namespace StarLens.Domain.Entities
{
    public class Telescope : Entity
    {
        public float FocalRatio { get; set; } = 0;
        public float Apperture { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
