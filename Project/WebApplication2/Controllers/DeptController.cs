using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/Dept")]
    public class DeptController : ApiControllerBase
    {
        public DeptController(ClaimAccessor claim, LibraryContext context) : base(claim, context)
        {
        }

        //List All Dept
        [Route("All")]
        [HttpGet]
        public IActionResult All() {
            try
            {
                var all = _context.Dept.ToList();
                return Ok(all);
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw (ex);
            }
        }

        //Insert Dept
        [Route("Create")]
        [HttpPost]
        public IActionResult Add([FromBody] Input insert) {
            try
            {
                var check = _context.Dept.Where(x => x.DeptNo == insert.no);
                var newDept = new Dept()
                {
                    DeptNo = insert.no,
                    DeptName = insert.name
                };
                _context.Dept.Add(newDept);
                _context.SaveChanges();
                var data = _context.Dept.ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

       //Delete Dept
       [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] Input delete) {
            try
            {
                var check = _context.Dept.SingleOrDefault(x => x.DeptNo == delete.no);
                if (check != null)
                {
                    _context.Dept.Remove(check);
                    _context.SaveChanges();
                    var data = _context.Dept.ToList();
                    return Ok(data);
                }
                else return Ok("查無此部門");
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //Edit Dept
        [Route("Update")]
        [HttpPost]
        public IActionResult Edit([FromBody] Input edit) {
            try
            {
                var check = _context.Dept.Where(x => x.DeptNo == edit.no);
                if (check == null)
                {
                    return Ok("查無此部門");
                }
                else {
                    var updata = new string[2] { edit.no, edit.name};
                    var updateStr = _context.Dept.AsQueryable();
                    if (edit.name != null) {
                        updateStr.Where(x => x.DeptNo == updata[0]).FirstOrDefault().DeptName = updata[1];
                        _context.Dept.UpdateRange(updateStr);
                        _context.SaveChanges();
                        var data = _context.Dept.ToList();
                        return Ok(data);
                    }                    
                    else return Ok("沒有改變");                    
                }
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }
        
        //List All Dept & Emp
        [Route("Emp")]
        [HttpGet]
        public IActionResult AllEmp() {
            try
            {
                var data = _context.Dept.OrderBy(d => d.DeptNo).Join(_context.Employee,
                    d => d.DeptNo,
                    e => e.DeptNo,
                    (d, e) => new
                    {
                        DeptName = d.DeptName,
                        EmpName = e.EmpName
                    });
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //List All Emp in the Dept
        [Route("PerDept")]
        [HttpGet]
        public IActionResult DeptEmp(string id) {
            try
            {
                var data = _context.Dept.Where(d => d.DeptNo == id).Join(_context.Employee,
                    d => d.DeptNo,
                    e => e.DeptNo,
                    (d, e) => new
                    {
                        DeptName = d.DeptName,
                        EmpName = e.EmpName
                    }).OrderBy(de=>de.EmpName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //public class Id { public string no { get; set; } }
        public class Input {
            public string no { get; set; }
            public string name { get; set; }
        }
    }
}
