using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class TypeOfDiet
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Typ diety")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Diety")]
        [JsonIgnore]
        public virtual List<Diet> Diets { get; set; }
    }
}