using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<MealIngridient> MealIngridients { get; set; }
        public virtual List<DietMeal> DietMeals { get; set; }
        public virtual List<MealOpinion> MealOpinions { get; set; }
    }
}