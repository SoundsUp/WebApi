using System;

namespace SoundsUp.Domain.Entities.Models
{
    public partial class Favorites
    {
        public int UserId { get; set; }
        public Guid TrackId { get; set; }

        public Tracks Track { get; set; }
        public Users User { get; set; }
    }
}