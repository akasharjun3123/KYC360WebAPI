namespace WebAPIAssignment.Model
{
    public class Date
    {
        public int DateId { get; set; }
        public string? DateType { get; set; }
        public DateTime? DateValue { get; set; }
        public int EntityId { get; set; }  // Foreign key
        public Entity Entity { get; set; } // Navigation property

    }
}
