namespace PropertyManagementSystem.Models.DTO
{
    public class RequestCreateDto
    {
        public int TenandId { get; set; }
        public int PropertyId { get; set; }
        public DateOnly MoveIn { get; set; }
        public DateOnly MoveOut { get; set; }
        public bool? IsAccepted { get; set; }
    }
}
