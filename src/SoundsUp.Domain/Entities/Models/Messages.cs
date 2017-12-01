using System;

namespace SoundsUp.Domain.Entities.Models
{
    public partial class Messages
    {
        public int Id { get; set; }
        public string MsgContent { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserTo { get; set; }
        public int UserFrom { get; set; }
        public Guid? TrackId { get; set; }

        public Tracks Track { get; set; }
        public Users UserFromNavigation { get; set; }
        public Users UserToNavigation { get; set; }
    }
}