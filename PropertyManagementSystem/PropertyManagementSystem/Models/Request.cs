namespace PropertyManagementSystem.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int TenandId { get; set; }
        public int PropertyId { get; set; }
        public DateOnly MoveIn { get; set; }
        public DateOnly MoveOut { get; set; }
        public bool IsAccepted { get; set; }
        public User Tenand { get; set; }
        public Property Property { get; set; }
    }
}
