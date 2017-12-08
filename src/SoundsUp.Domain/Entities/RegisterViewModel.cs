using System.ComponentModel.DataAnnotations;
namespace SoundsUp.Domain.Entities
{
    public class RegisterViewModel
    {
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
    }
}