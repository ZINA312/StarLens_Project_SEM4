using System.Text.Json.Serialization;

namespace StarLens.Domain.Entities
{
    public class Session : Entity
    {
        public Session(string date, int frames, float exposure, int gain, int offset,
            int telescopeId, int cameraId, int mountId, int filterId)
        {
            Date = date;
            NumOfFrames = frames;
            Exposure = exposure;
            Gain = gain;
            Offset = offset;
            Equipment = new Equipment();
            Equipment.TelescopeId = telescopeId;
            Equipment.CameraId = cameraId;
            Equipment.MountId = mountId;
            Equipment.FilterId = filterId;
        }

        [JsonConstructor]
        public Session(Equipment equipment, string date, int numOfFrames,
                       float exposure, int gain, int offset, int id)
        {
            Equipment = equipment;
            Date = date;
            NumOfFrames = numOfFrames;
            Exposure = exposure;
            Gain = gain;
            Offset = offset;
            Id = id;
        }

        public Equipment Equipment { get; set; }
        public string Date { get; set; } = string.Empty;
        public int NumOfFrames { get; set; } = 0;
        public float Exposure { get; set; } = 0;
        public int Gain { get; set; } = 0;
        public int Offset { get; set; } = 0;
    }
}