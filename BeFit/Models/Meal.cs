using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa posiłku")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Składniki posiłku")]
        [JsonIgnore]
        public virtual List<MealIngridientMeal> MealIngridientMeals { get; set; }

        [Display(Name = "Posiłek diety")]
        [JsonIgnore]
        public virtual List<DietMeal> DietMeals { get; set; }

        [Display(Name = "Opinie o posiłku")]
        [JsonIgnore]
        public virtual List<MealOpinion> MealOpinions { get; set; }
    }
}