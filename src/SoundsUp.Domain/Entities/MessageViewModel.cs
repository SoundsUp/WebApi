using System;
using System.ComponentModel.DataAnnotations;

namespace SoundsUp.Domain.Entities
{
    public class MessageViewModel : MessageContentViewModel
    {
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
    }
}