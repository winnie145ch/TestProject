using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Route("From")]
    public class FromController : APIControllerBase
    {
        // POST: api/From/{path}?query={query}
        [HttpGet("{path}")]
        public ActionResult From( [FromHeader]string value, [FromRoute]int path, [FromQuery]int query)
        {
            value = "Salute";
            return Content($"route : {path} ,query : {query} ,header : {value}");
        }
    }
}
