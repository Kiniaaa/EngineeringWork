using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Adres email")]
        public string Email { get; set; }

        public string password_hash { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Display(Name = "Usunięto")]
        public bool Deleted { get; set; }

        [Display(Name = "Rola")]
        public string roleName { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }


        [JsonIgnore]
        public virtual List<MealOpinion> MealOpinions { get; set; }
        [JsonIgnore]
        public virtual List<PhysicalActivity> PhysicalActivities { get; set; }
        [JsonIgnore]
        public virtual List<Diet> Diets { get; set; }
        [JsonIgnore]
        public virtual List<CustomerData> CustomerDatas { get; set; }
        [JsonIgnore]
        public virtual List<Message> Messages { get; set; }
    }
}