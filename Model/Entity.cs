namespace WebAPIAssignment.Model
{
    public interface IEntity
    {
        public List<Address> Addresses { get; set; }
        public List<Date> Dates { get; set; }
        public bool Deceased { get; set; }
        public string Gender { get; set; }
        public int EntityId { get; set; }
        public List<Name> Names { get; set; }
    }

    public class Entity : IEntity
    {
        public List<Address> Addresses { get; set; }
        public List<Date> Dates { get; set; }
        public bool Deceased { get; set; }
        public string Gender { get; set; }
        public int EntityId { get; set; }
        public List<Name> Names { get; set; }

    }

    
}
