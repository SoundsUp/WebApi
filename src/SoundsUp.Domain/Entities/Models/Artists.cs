using System;
using System.Collections.Generic;

namespace SoundsUp.Domain.Entities.Models
{
    public partial class Artists
    {
        public Artists()
        {
            Discographies = new HashSet<Discographies>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Discographies> Discographies { get; set; }
    }
}