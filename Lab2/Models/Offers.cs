using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Offers
    {
        public Offers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int IdMedicine { get; set; }
        public int IdProvider { get; set; }
        public decimal Price { get; set; }

        public virtual Medicines IdMedicineNavigation { get; set; }
        public virtual Providers IdProviderNavigation { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
