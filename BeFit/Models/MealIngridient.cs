using Newtonsoft.Json;
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
        public int IngridientId { get; set; }

        [JsonIgnore]
        public virtual Meal Meal { get; set; }
        [JsonIgnore]
        public virtual Ingridient Ingridient { get; set; }

    }
}