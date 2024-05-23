namespace StarLens.Domain.Entities
{
    public class Equipment : Entity
    {
        public List<Telescope> Telescopes { get; set; } = [];
        public List<Mount> Mounts { get; set; } = [];
        public List<Camera> Cameras { get; set; } = [];
        public List<Filter> Filters { get; set; } = [];
        public List<Accessory> Accessories { get; set; } = [];
    }
}
