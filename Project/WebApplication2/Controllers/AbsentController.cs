using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;
using WebApplication2.Models;
using WebApplication2.Helpers;

namespace WebApplication2.Controllers
{
    [Route("api/Absent")]
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
        public IActionResult AddOff([FromBody] Input offical)
        {
            AbsentHelper absent = new AbsentHelper();
            try
            {
                var check = _context.AbsDetail.Where(x => x.EmpNo == offical.id && x.AbsDate == Convert.ToDateTime(offical.date, culinfo));
                if (check == null)
                {
                    var sex = _context.Employee.Where(x => x.EmpNo == offical.id).Select(x => x.Sex).FirstOrDefault();
                    var dept = _context.Employee.Where(x => x.EmpNo == offical.id).Select(x => x.DeptNo).FirstOrDefault();
                    var past = _context.AbsDetail.Where(x => x.EmpNo == offical.id && x.AbsType == "5").Select(x => x.AbsHour).Sum() / 9;
                    var available = absent.OfficalAvailable(sex, dept, past,_claim._config.Absent["Offical"]);
                    if (available == true)
                    {
                        var newAbs = new AbsDetail()
                        {
                            EmpNo = offical.id,
                            AbsType = "5",
                            AbsDate = Convert.ToDateTime(offical.date, culinfo),
                            AbsHour = Int32.Parse(offical.hours)
                        };
                        _context.AbsDetail.Add(newAbs);
                        _context.SaveChanges();
                        var data = _context.AbsDetail.Where(x => x.EmpNo == offical.id).OrderBy(x=>x.AbsDate).ToList();
                        return Ok(data);
                    }
                    else return Ok("已超過休假額度");
                }
                else return Ok("已安排休假");
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //Helper: AbsentHelper
        //Insert Absent: Sick
        [Route("Sick")]
        [HttpPost]
        public IActionResult AddSick([FromBody] Input sick)
        {
            AbsentHelper absent = new AbsentHelper();
            try
            {
                var check = _context.AbsDetail.Where(x => x.EmpNo == sick.id && x.AbsDate == Convert.ToDateTime(sick.date, culinfo));
                if (check == null)
                {
                    var sex = _context.Employee.Where(x => x.EmpNo == sick.id).Select(x => x.Sex).FirstOrDefault();
                    var dept = _context.Employee.Where(x => x.EmpNo == sick.id).Select(x => x.DeptNo).FirstOrDefault();
                    var past = _context.AbsDetail.Where(x => x.EmpNo == sick.id && x.AbsType == "3").Select(x => x.AbsHour).Sum() / 9;
                    var available = absent.OfficalAvailable(sex, dept, past, _claim._config.Absent["Sick"]);
                    if (available == true)
                    {
                        var newAbs = new AbsDetail()
                        {
                            EmpNo = sick.id,
                            AbsType = "3",
                            AbsDate = Convert.ToDateTime(sick.date, culinfo),
                            AbsHour = Int32.Parse(sick.hours)
                        };
                        _context.AbsDetail.Add(newAbs);
                        _context.SaveChanges();
                        var data = _context.AbsDetail.Where(x => x.EmpNo == sick.id).OrderBy(x => x.AbsDate).ToList();
                        return Ok(data);
                    }
                    else return Ok("已超過休假額度");
                }
                else return Ok("已安排休假");
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //Insert Absent: Personal
        [Route("Personal")]
        [HttpPost]
        public IActionResult AddPer([FromBody] Input personal)
        {
            try
            {
                var check = _context.AbsDetail.Where(x => x.EmpNo == personal.id && x.AbsDate == Convert.ToDateTime(personal.date, culinfo));
                if (check == null)
                {
                    var newAbs = new AbsDetail()
                    {
                        EmpNo = personal.id,
                        AbsType = "4",
                        AbsDate = Convert.ToDateTime(personal.date, culinfo),
                        AbsHour = Int32.Parse(personal.hours)
                    };
                    _context.AbsDetail.Add(newAbs);
                    _context.SaveChanges();
                    var data = _context.AbsDetail.Where(x => x.EmpNo == personal.id).OrderBy(x => x.AbsDate).ToList();
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

        //Helper: AbsentHelper
        //search
        [Route("search")]
        [HttpGet]
        public IActionResult Ser(string id) {
            try
            {                
                var sex = _context.Employee.Where(x => x.EmpNo == id).Select(x => x.Sex).FirstOrDefault();
                var dept = _context.Employee.Where(x => x.EmpNo == id).Select(x => x.DeptNo).FirstOrDefault();
                var Off = _context.AbsDetail.Where(x => x.EmpNo == id && x.AbsType == "5").Select(x => x.AbsHour).Sum() / 9;
                var Sick = _context.AbsDetail.Where(x => x.EmpNo == id && x.AbsType == "3").Select(x => x.AbsHour).Sum() / 9;
                AbsentHelper absent = new AbsentHelper();
                var search = absent.Search(sex,dept,Off,Sick,_claim._config.Absent["Offical"],_claim._config.Absent["Sick"]);
                return Ok(search);
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
