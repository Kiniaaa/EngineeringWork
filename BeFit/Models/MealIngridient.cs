using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class MealIngridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public int IngridientId { get; set; }
        public virtual Ingridient Ingridient { get; set; }

    }
}