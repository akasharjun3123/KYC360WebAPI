namespace WebAPIAssignment.Model
{
    public class Address
    {   
        
        public int AddressId { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int EntityId { get; set; }  
        public Entity Entity { get; set; } 
    }
}
