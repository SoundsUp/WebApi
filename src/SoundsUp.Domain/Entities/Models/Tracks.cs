using System;
using System.Collections.Generic;

namespace SoundsUp.Domain.Entities.Models
{
    public partial class Tracks
    {
        public Tracks()
        {
            Favorites = new HashSet<Favorites>();
            Messages = new HashSet<Messages>();
        }

        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public string SpotifyUrl { get; set; }
        public string PreviewUrl { get; set; }

        public Albums Album { get; set; }
        public ICollection<Favorites> Favorites { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}