using System;
using System.Collections.Generic;

namespace Lab2
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int IdBranch { get; set; }
        public decimal Salary { get; set; }

        public virtual Branches IdBranchNavigation { get; set; }
    }
}
