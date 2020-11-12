using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class PhysicalActivity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Spalone kalorie")]
        public int CaloriessBurned { get; set; }

        [Display(Name = "Data i godzina aktywności")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateActivity { get; set; }


        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int UserId { get; set; }

        [Display(Name = "Użytkownik")]
        [JsonIgnore]
        public virtual User Customer { get; set; }
    }
}