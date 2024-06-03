namespace StarLens.Domain.Entities
{
    public class Telescope : Entity
    {
        public Telescope(string name, string type, float focalratio, float apperture) 
        {
            Name = name;
            Type = type;
            FocalRatio = focalratio;
            Apperture = apperture;
        }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public float FocalRatio { get; set; } = 0;
        public float Apperture { get; set; } = 0;
    }
}
