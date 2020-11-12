using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class Diet
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Wartość energetyczna")]
        public int EnergeticValue { get; set; }

        [Display(Name = "Data rozpoczęcia diety")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Required]
        [Display(Name = "Czas trwania diety")]
        public int Duration { get; set; }

        [Display(Name = "Opinia o dietetyku")]
        public string DieticianOpinion { get; set; }

        [Display(Name = "Ocena dietetyka")]
        [Range(0, 5)]
        public int DieticianRate { get; set; }

        [Display(Name = "Opinia o diecie")]
        public string DietOpinion { get; set; }

        [Display(Name = "Ocena diety")]
        [Range(0,5)]
        public int DietRate { get; set; }

        [Display(Name = "Dodatkowe informacje dla dietetyka")]
        public string AdditionalWarning { get; set; }
        public int TypeOfDietId { get; set; }

        [Display(Name = "Typ diety")]
        [JsonIgnore]
        public virtual TypeOfDiet TypeOfDiet { get; set; }

        [Display(Name = "Użytkownik")]
        [JsonIgnore]
        public virtual User Customer { get; set; }

        [Display(Name = "Dietetyk")]
        [JsonIgnore]
        public virtual User Dietician { get; set; }

        [Display(Name = "Posiłki diety")]
        [JsonIgnore]
        public virtual List<DietMeal> DietMeals { get; set; }


    }
}