using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class DietMeal
    {
        public int Id { get; set; }

        [Display(Name = "Data i godzina zjedzenia posiłku")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfEating { get; set; }

        public int DietId { get; set; }
        public int MealId { get; set; }
        public int TypeOfMealId { get; set; }
        public int MealOpinionId { get; set; }

        [Display(Name = "Posiłek")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        [Display(Name = "Dieta")]
        [JsonIgnore]
        public virtual Diet Diet { get; set; }

        [Display(Name = "Typ posiłku")]
        [JsonIgnore]
        public virtual TypeOfMeal TypeOfMeal { get; set; }

        [Display(Name = "Opinia o posiłku")]
        [JsonIgnore]
        public virtual MealOpinion MealOpinion { get; set; }

    }
}