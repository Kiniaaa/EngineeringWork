using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class TypeOfMeal
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }


        [Display(Name = "Posiłki")]
        [JsonIgnore]
        public virtual List<DietMeal> DietMeals { get; set; }
    }
}