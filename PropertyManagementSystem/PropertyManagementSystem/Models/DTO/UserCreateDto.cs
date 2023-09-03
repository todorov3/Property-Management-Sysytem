using System.ComponentModel.DataAnnotations;

namespace PropertyManagementSystem.Models.DTO
{
    public class UserCreateDto
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 35;
        private const int EmailMinLength = 3;
        private const int EmailMaxLength = 75;
        private const int PhoneNumberMinLength = 7;
        private const int PhoneNumberMaxLength = 14;
        private const int PasswordMinLength = 6;
        private const int PasswordMaxLength = 35;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Username { get; set; }

        [Required]
        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string Email { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "The {0} must be between {1} and {2} characters long.")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "The password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
