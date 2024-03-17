namespace WebAPIAssignment.Model
{
    public class UpdateEntityDTO
    {   
        public List<AddressDto> Addresses { get; set; }
        public List<DateDto> Dates { get; set; }
        public bool Deceased { get; set; }
        public string Gender { get; set; }
        public List<NameDto> Names { get; set; }
    }

    public class AddEntityDTO : UpdateEntityDTO
    {
        public int EntityId { get; set; }
    }

    public class AddressDto
    {
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
    }

    public class DateDto
    {
        public string DateType { get; set; }
        public DateTime? DateValue { get; set; }
    }

    public class NameDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
    }
}
