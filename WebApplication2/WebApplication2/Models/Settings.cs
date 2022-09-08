using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Settings
    {
        public string Default { get; set; }
        public string Plus { get; set; }
        public string Version { get; set; }
        public string Token { get; set; }
        public Dictionary<string, int> Absent { get; set; }
    }
}
