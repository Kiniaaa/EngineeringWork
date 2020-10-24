using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class TypeOfDiet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Diet> Diets { get; set; }
    }
}