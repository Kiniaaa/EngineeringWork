using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class MealOpinion
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ocena Posiłku")]
        [Range(1,5)]
        public int MealRate { get; set; }

        [Display(Name = "Data i godzina wystawienia opinii")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}")]
        public DateTime DateOpinion { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int MealId { get; set; }
        public int UserId { get; set; }
        public int DietMealId { get; set; }

        [Display(Name = "Użytkownik")]
        [JsonIgnore]
        public virtual User Customer { get; set; }

        [Display(Name = "Posiłek")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        [Display(Name = "Posiłek diety")]
        [JsonIgnore]
        public virtual DietMeal DietMeal { get; set; }

    }
}