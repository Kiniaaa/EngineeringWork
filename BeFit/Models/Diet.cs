using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EnergeticValue { get; set; }
        public DateTime DateStart { get; set; }
        public int Duration { get; set; }
        public string DieticianOpinion { get; set; }
        public int DieticianRate { get; set; }
        public string DietOpinion { get; set; }
        public int DietRate { get; set; }
        public string AdditionalWarning { get; set; }

        public int TypeOfDietId { get; set; }
        public virtual TypeOfDiet TypeOfDiet { get; set; }
        
         public int UserId { get; set; }
         public virtual User Customer { get; set; }
         public virtual User Dietician { get; set; }

        public virtual List<DietMeal> DietMeals { get; set; }


    }
}