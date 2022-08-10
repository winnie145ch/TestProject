using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers.HomeWork_chp4
{
    [Produces("application/json")]
    [Route("Post")]
    public class PostController : APIControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] Users user)
        {
            Users abc = new Users()
            {
                id = 1,
                name = "somebody"
            };
            return Ok(abc);
        }

        public class Users
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}