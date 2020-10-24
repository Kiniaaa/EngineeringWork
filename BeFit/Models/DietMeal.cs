using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class DietMeal
    {
        public int Id { get; set; }
        public DateTime DateOfEating { get; set; }

        public int DietId { get; set; }
        public virtual Diet Diet { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int TypeOfMealId { get; set; }
        public virtual TypeOfMeal TypeOfMeal { get; set; }

    }
}