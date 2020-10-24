using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Ingridient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EnergeticValue { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float CarboHydrates { get; set; }
        public MeasureRate? MeasureRate { get; set; }

        [JsonIgnore]
        public virtual List<MealIngridient> MealIngridients { get; set; }

    }
    public enum MeasureRate
    {
        g, ml
    }
}