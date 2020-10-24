using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeFit.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public Name? Name { get; set; }

        public virtual List<User> Users { get; set; }
    }

    public enum Name
    {
        Dietetyk, Klient
    }
}