using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class CustomerData
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:F2}")]
        [Display(Name = "Waga")]
        public Decimal Weight { get; set; }

        [Required]
        [Display(Name = "Wzrost")]
        public int Growth { get; set; }

        [Required]
        [Display(Name = "Data pomiaru")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfMeasurement { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Użytkownik")]
        [JsonIgnore]
        public virtual User Customer { get; set; }
    }
}