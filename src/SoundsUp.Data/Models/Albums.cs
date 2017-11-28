using System;
using System.Collections.Generic;

namespace SoundsUp.Data.Models
{
    public partial class Albums
    {
        public Albums()
        {
            Discographies = new HashSet<Discographies>();
            Tracks = new HashSet<Tracks>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] ImageUrl { get; set; }

        public ICollection<Discographies> Discographies { get; set; }
        public ICollection<Tracks> Tracks { get; set; }
    }
}
