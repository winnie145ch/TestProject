using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api/Hello")]
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Get() {
            try
            {
                return Ok(new Response("Hello World ( ◍•㉦•◍ )"));
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }
    }
}