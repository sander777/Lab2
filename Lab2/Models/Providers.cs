using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Providers
    {
        public Providers()
        {
            Offers = new HashSet<Offers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Offers> Offers { get; set; }
    }
}
