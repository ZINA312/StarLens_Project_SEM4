namespace StarLens.Domain.Entities
{
    public class Equipment : Entity
    {
        public int TelescopeId { get; set; }
        public int MountId { get; set; }
        public int CameraId { get; set; }
        public int FilterId { get; set; }
    }
}
