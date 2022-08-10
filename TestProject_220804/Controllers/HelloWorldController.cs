using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Route("HelloWorld")]
    public class HelloWorldController : APIControllerBase
    {
        // GET api/HelloWorld
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello World ╰(*°▽°*)╯" };
        }
    }
}
