using System;

namespace SoundsUp.Domain.Entities
{
    public class MessageViewModel
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public string MsgContent { get; set; }
        public DateTime Time { get; set; }
    }
}