using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    public class AbsentController : ApiControllerBase
    {
        public AbsentController(ClaimAccessor claim, LibraryContext context) : base(claim, context)
        {
        }
        CultureInfo culinfo = new CultureInfo("zh-TW");

        //Helper: AbsentHelper
        //Insert Absent: Offical
        [Route("Offical")]
        [HttpPost]
        public IActionResult Add([FromBody] Input offical)
        {
            try
            {
                var check = _context.AbsDetail.Where(x => x.EmpNo == offical.id && x.AbsDate == Convert.ToDateTime(offical.date, culinfo));
                if (check != null)
                {
                    var newAbs = new AbsDetail()
                    {
                        EmpNo = offical.id,
                        AbsType = "1",
                        AbsDate = Convert.ToDateTime(offical.date, culinfo),
                        AbsHour = Int32.Parse(offical.hours)
                    };
                    _context.AbsDetail.Add(newAbs);
                    _context.SaveChanges();
                    var data = _context.AbsDetail.ToList();
                    return Ok(data);
                }
                else return Ok("已安排休假");
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        public class Input
        {
            public string id { get; set; }
            public string date { get; set; }
            public string hours { get; set; }
        }
    }
}
