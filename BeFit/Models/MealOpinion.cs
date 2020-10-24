using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class MealOpinion
    {
        public int Id { get; set; }
        public int MealRate { get; set; }
        public DateTime DateOpinion { get; set; }
        public string Description { get; set; }

       
        public int UserId { get; set; }
        public virtual User Customer { get; set; }
        public virtual List<Meal> Meals { get; set; }

    }
}