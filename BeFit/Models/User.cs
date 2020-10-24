using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public bool Deleted { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual List<MealOpinion> MealOpinions { get; set; }
        public virtual List<PhysicalActivity> PhysicalActivities { get; set; }
        public virtual List<Diet> Diets { get; set; }
        public virtual List<CustomerData> CustomerDatas { get; set; }
    }
}