﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class MealIngridient
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ilość")]
        public int Quantity { get; set; }
        public int MealId { get; set; }
        public int IngridientId { get; set; }

        [Display(Name ="Posiłki")]
        [JsonIgnore]
        public virtual Meal Meal { get; set; }

        [Display(Name ="Składniki")]
        [JsonIgnore]
        public virtual Ingridient Ingridient { get; set; }

    }
}