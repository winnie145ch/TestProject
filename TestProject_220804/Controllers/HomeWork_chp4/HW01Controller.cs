using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Route("api/HW01")]
    public class HW01Controller : APIControllerBase
    {
        // api/HW01/Status200
        [Route("Status200")]
        [HttpGet]
        public IActionResult Status200()
        {
            try
            {
                return Ok();
            }
            catch
            {
                throw;
            }
        }

        // api/HW01/Status401
        [Route("Status401")]
        [HttpGet]
        public IActionResult Status401()
        {
            try
            {
                return Unauthorized();
            }
            catch
            {
                throw;
            }
        }

        // api/HW01/Status500
        [Route("Status500")]
        [HttpGet]
        public IActionResult Status500()
        {
            try
            {
                return null;
            }
            catch
            {
                throw;
            }
        }

        // api/HW01/List
        [Route("List")]
        [HttpGet]
        public List<Greet> List()
        {
            List<Greet> greet = new List<Greet>();
            for (int i = 0; i < 10; i++)
            {
                greet.Add(new Greet
                {
                    sid = i,
                    hello = "你好 * " + i
                });
            }
            return greet;
            //return new List<Greet>{new Greet {sid = 100, hello = "hello"}, new Greet{sid = 200, hello = "Hola"}};
        }

        // api/HW01/Dict
        [Route("Dict")]
        [HttpGet]
        public Dictionary<string, string> Dict()
        {
            return new Dictionary<string, string> {
                { "Language","Spanish" },
                { "Spelling","chao"},
                { "Synonym","adiós"},
                { "Meaning","bye"}
            };
        }

        // api/HW01/Class
        [Route("Class")]
        [HttpGet]
        public Appreciate Class()
        {
            return new Appreciate
            {
                id = 1,
                lang = "Spanish",
                spell = "gracias",
                mean = "thanks"
            };
        }
        
        //classes
        public class Greet
        {
            public int sid { set; get; }
            public string hello { set; get; }
        }
        public class Appreciate
        {
            public int id { set; get; }
            public string lang { set; get; }
            public string spell { set; get; }
            public string mean { set; get; }
        }
    }
}