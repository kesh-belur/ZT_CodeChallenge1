using CodeChallenge1.CustomAttributes;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge1.Models
{
    public class UserCreationDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128, ErrorMessage = "The maximum length of First Name cannot exceed 128 characters.")]
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = String.Empty;
        [Required]
        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
        [Required]
        [DateOfBirth(MinAge = 18)]
        public DateTime DateOfBirth { get; set; }
    }
}
