using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Route("/Inherit")]
    public class InheritController : APIControllerBase {
        // GET: api/Inherit
        [HttpGet]
        public string Greet1() {
            sayHi hello = new sayHi("World ʕ •ᴥ•ʔ");
            return hello.greeting.ToString();
        }

        [HttpGet("{word}")]
         public string Greet2(string word) {
             sayHi Spanish = new sayHi(word);             
             return Spanish.greeting.ToString();
         }
    }
}
