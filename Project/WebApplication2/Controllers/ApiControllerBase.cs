using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Produces("application/json")]
    [Route("api/Api")]
    public class ApiControllerBase : ControllerBase
    {
        private ClaimAccessor _claim;
        public LibraryContext _context;
        public ApiControllerBase(ClaimAccessor claim, LibraryContext context) {
            _claim = claim;
            _context = context;
        }
    }
}
