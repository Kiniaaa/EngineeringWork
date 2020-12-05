using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Ingridient
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Wartość energetyczna")]
        public int EnergeticValue { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Tłuszcz")]
        public Decimal Fat { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Białko")]
        public Decimal Protein { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Węglowodany")]
        public Decimal CarboHydrates { get; set; }

        [Required]
        [Display(Name = "Jednostka miary")]
        public MeasureRate MeasureRate { get; set; }

        
        [Display(Name = "SKładniki posiłków")]
        [JsonIgnore]
        public virtual List<MealIngridient> MealIngridients { get; set; }

    }
    public enum MeasureRate
    {
        gramy, mililitry
    }
}