namespace StarLens.Domain.Entities
{
    public class Session : Entity
    {
        public string Date { get; set; } = string.Empty;
        public int NumOfFrames { get; set; } = 0;
        public float Exposure { get; set; } = 0;
        public Filter? Filter { get; set; }
        public int Gain { get; set; } = 0;
        public int Offset { get; set; } = 0;
    }
}
