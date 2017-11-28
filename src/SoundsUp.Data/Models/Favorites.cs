using System;
using System.Collections.Generic;

namespace SoundsUp.Data.Models
{
    public partial class Favorites
    {
        public int UserId { get; set; }
        public Guid TrackId { get; set; }

        public Tracks Track { get; set; }
        public Users User { get; set; }
    }
}
