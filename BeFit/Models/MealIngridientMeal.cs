using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class MealIngridientMeal
    {
        public int id { get; set; }
        public int MealId { get; set; }
        [Display(Name = "Posiłki")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        public int MealIngridientId { get; set; }
        [Display(Name = "Składniki posiłku")]
        [JsonIgnore]
        public virtual MealIngridient MealIngridient { get; set; }
        
    }
}