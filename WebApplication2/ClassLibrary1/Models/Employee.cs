using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AbsDetail = new HashSet<AbsDetail>();
        }

        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Sex { get; set; }
        public string DeptNo { get; set; }
        public int Salary { get; set; }
        public string Brithday { get; set; }

        public Dept DeptNoNavigation { get; set; }
        public ICollection<AbsDetail> AbsDetail { get; set; }
    }
}
