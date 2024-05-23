namespace StarLens.Domain.Entities
{
    public class Camera : Entity
    {
        public Camera(string name, string type, float pixelsize, float sensorwidth, float sensorheight, bool iscooled, int quantumeff) 
        {
            Name = name;
            Type = type;
            PixelSize = pixelsize;
            SensorWidth = sensorwidth;
            SensorHeight = sensorheight;
            IsCooled = iscooled;
            QuantumEfficiency = quantumeff;
        }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public float PixelSize { get; set; } = 0;
        public float SensorWidth { get; set; } = 0;
        public float SensorHeight { get; set; } = 0;
        public bool IsCooled { get; set; } = false;
        public int QuantumEfficiency { get; set; } = 0;
    }
}
