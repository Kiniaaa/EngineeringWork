using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Message
    {
        public int Id { get; set; }


        [Display(Name = "Nadawca")]
        [JsonIgnore]
        public virtual User Sender { get; set; }

        [Display(Name = "Odbiorca")]
        [JsonIgnore]
        public virtual User Receiver { get; set; }

        [Required]
        [MinLength(2)]
        [JsonIgnore]
        [Display(Name = "Treść wiadomości")]
        public String Content { get; set; }


    }
}