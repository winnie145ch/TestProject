using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class Absent
    {
        public Absent()
        {
            AbsDetail = new HashSet<AbsDetail>();
        }

        public string AbsType { get; set; }
        public string AbsName { get; set; }

        public ICollection<AbsDetail> AbsDetail { get; set; }
    }
}
