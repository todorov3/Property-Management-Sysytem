namespace PropertyManagementSystem.Models.DTO
{
    public class PropertyUpdateDto
    {
        public bool? PetsAllowed { get; set; }
        public decimal Price { get; set; }
        public DateOnly FreeDates { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
