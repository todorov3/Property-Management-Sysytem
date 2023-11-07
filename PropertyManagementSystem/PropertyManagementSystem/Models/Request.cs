namespace PropertyManagementSystem.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int TenandId { get; set; }
        public int PropertyId { get; set; }
        public DateTime MoveIn { get; set; }
        public DateTime MoveOut { get; set; }
        public int IsAccepted { get; set; }
        public bool IsDeleted { get; set; }
        public User Tenant { get; set; }
        public Property Property { get; set; }
    }
}
