namespace PropertyManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public IFormFile? Photo { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
