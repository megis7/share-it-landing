using System;
using System.ComponentModel.DataAnnotations;

namespace shareit.Models
{
    public class Subscriber
    {
        [Key]
        public string Email { get; set; }

        public DateTime RegisteredDateTime { get; set; }
    }
}