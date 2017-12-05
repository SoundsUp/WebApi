using System.Collections.Generic;

namespace SoundsUp.Domain.Entities.Models
{
    public partial class Users
    {
        public Users()
        {
            Favorites = new HashSet<Favorites>();
            MessagesUserFromNavigation = new HashSet<Messages>();
            MessagesUserToNavigation = new HashSet<Messages>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }

        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<Messages> MessagesUserFromNavigation { get; set; }
        public ICollection<Messages> MessagesUserToNavigation { get; set; }
    }
}