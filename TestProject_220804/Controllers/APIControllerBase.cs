using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class APIControllerBase : ControllerBase
    {
        public class sayHi
        {
            public string greeting { get; set; }
            public sayHi(string greet)
            {
                greeting = "Hello " + greet;
            }
        }
    }

}