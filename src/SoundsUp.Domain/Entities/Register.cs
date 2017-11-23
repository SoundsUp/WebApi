namespace SoundsUp.Domain.Entities
{
    public class Register
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
    }
}