using System;
using System.Collections.Generic;

namespace ClassLibrary2.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Employee = new HashSet<Employee>();
        }

        public string DeptNo { get; set; }
        public string DeptName { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
