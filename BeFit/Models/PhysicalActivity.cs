using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class PhysicalActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaloriessBurned { get; set; }
        public DateTime DateActivity { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public virtual User Customer { get; set; }
    }
}