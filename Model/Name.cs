namespace WebAPIAssignment.Model
{
    public class Name
    {
        public int NameId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
        public int EntityId { get; set; }  // Foreign key
        public Entity Entity { get; set; } // Navigation property
    }

    
}
