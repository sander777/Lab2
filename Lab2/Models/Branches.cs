using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Branches
    {
        public Branches()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
