using System;
using System.Collections.Generic;

namespace SoundsUp.Data.Models
{
    public partial class Discographies
    {
        public Guid ArtistId { get; set; }
        public Guid AlbumId { get; set; }

        public Albums Album { get; set; }
        public Artists Artist { get; set; }
    }
}
