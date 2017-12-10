using System;
using System.ComponentModel.DataAnnotations;

namespace SoundsUp.Domain.Entities
{
    public class MessageViewModel
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        [Required]
        public string MsgContent { get; set; }
    }
}