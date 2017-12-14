using System;
using System.ComponentModel.DataAnnotations;

namespace SoundsUp.Domain.Entities
{
    public class MessageContentViewModel
    {
        [Required]
        public string MsgContent { get; set; }
    }
}