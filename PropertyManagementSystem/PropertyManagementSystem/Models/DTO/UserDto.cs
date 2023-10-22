namespace PropertyManagementSystem.Models.DTO
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
