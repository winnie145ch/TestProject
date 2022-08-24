using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject_220804.Helpers.Filters;
using TestProject_220804.Models;

namespace TestProject_220804.Controllers
{
    [Produces("application/json")]
    [Route("api/TokenRes")]
    public class TokenResController : Controller
    {
        [AuthorizationFilter]
        [Route("token")]
        [HttpGet]
        public IActionResult Token()
        {
            try
            {
                return Ok("123");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Res() {
            try
            {
                return Ok(new ResponseFormat("test"));
            }
            catch (Exception ex)
            {
                return Ok(new ResponseFormat(ex));
                throw;
            }
        }
    }
}
