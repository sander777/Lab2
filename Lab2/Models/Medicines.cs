using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Medicines
    {
        public Medicines()
        {
            Offers = new HashSet<Offers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Limitation { get; set; }

        public virtual ICollection<Offers> Offers { get; set; }
    }
}
