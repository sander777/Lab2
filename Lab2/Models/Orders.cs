using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int IdBranch { get; set; }
        public int IdOffer { get; set; }
        public int Amount { get; set; }

        public virtual Branches IdBranchNavigation { get; set; }
        public virtual Offers IdOfferNavigation { get; set; }
    }
}
