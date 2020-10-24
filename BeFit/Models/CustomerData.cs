using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class CustomerData
    {
        public int Id { get; set; }
        public float Weight { get; set; }
        public int Growth { get; set; }
        public DateTime DateOfMeasurement { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User Customer { get; set; }
    }
}