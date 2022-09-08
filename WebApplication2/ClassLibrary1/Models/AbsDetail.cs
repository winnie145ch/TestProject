using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class AbsDetail
    {
        public string EmpNo { get; set; }
        public string AbsType { get; set; }
        public DateTime AbsDate { get; set; }
        public int AbsHour { get; set; }

        public Absent AbsTypeNavigation { get; set; }
        public Employee EmpNoNavigation { get; set; }
    }
}
