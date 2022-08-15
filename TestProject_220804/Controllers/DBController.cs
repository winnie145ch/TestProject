using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Produces("application/json")]
    [Route("api/DB")]
    public class DBController : APIControllerBase
    {
        public ClassLibrary2.Models._DB120999Context _context;
        public DBController(ClassLibrary2.Models._DB120999Context context) {
            _context = context;
        }

        // GET: api/DB
        [HttpGet]
        public ActionResult Result() {
            try {
                var a = _context.Employee.Where(x => x.Salary >= 75000).OrderBy(x=>x.Salary).ToList();
                return Ok(a);
            }
            catch {
                throw;
            }
        }
        
        
    }
}
