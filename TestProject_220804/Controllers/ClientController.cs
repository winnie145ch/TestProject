using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Produces("application/json")]
    [Route("api/Client")]
    public class ClientController : APIControllerBase
    {
        // GET: api/Client
        [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                //var client = new HttpClient();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
