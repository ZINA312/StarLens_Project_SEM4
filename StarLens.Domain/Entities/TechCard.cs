namespace StarLens.Domain.Entities
{
    public class TechCard : Entity
    {
        public TechCard( List<Session> sessions)
        {
            Sessions = sessions;
        }
        public List<Session> Sessions { get; set; } = [];
    }
}
