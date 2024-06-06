using System.Text.Json.Serialization;

namespace StarLens.Domain.Entities
{
    public class Equipment : Entity
    {
        [JsonConstructor]
        public Equipment(int telescopeId, int mountId, int cameraId,
                                 int filterId, int id)
        {
            this.TelescopeId = telescopeId;
            this.MountId = mountId;
            this.CameraId = cameraId;
            this.FilterId = filterId;
            this.Id = id;
        }
        public Equipment() { }
        public int TelescopeId { get; set; }
        public int MountId { get; set; }
        public int CameraId { get; set; }
        public int FilterId { get; set; }
    }
}
