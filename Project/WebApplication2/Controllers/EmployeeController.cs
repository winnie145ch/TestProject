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
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(ClaimAccessor claim, LibraryContext context) : base(claim, context)
        {
        }

        //Insert Emp
        [Route("Create")]
        [HttpPost]
        public IActionResult Add([FromBody] Input insert)
        {
            try
            {
                var check = _context.Employee.Where(x => x.EmpNo == insert.id);
                var newEmp = new Employee()
                {
                    EmpNo = insert.id,
                    EmpName = insert.name,
                    Sex = insert.sex,
                    DeptNo = insert.dept,
                    Salary = Int32.Parse(insert.payment),
                    Brithday = insert.bday
                };
                _context.Employee.Add(newEmp);
                _context.SaveChanges();
                var data = _context.Employee.ToList();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //Delete Emp
        [Route("Delete")]
        [HttpPost]
        public IActionResult Delete([FromBody] Input delete)
        {
            try
            {
                var check = _context.Employee.SingleOrDefault(x => x.EmpNo == delete.id);
                if (check != null)
                {
                    _context.Employee.Remove(check);
                    _context.SaveChanges();
                    var data = _context.Employee.ToList();
                    return Ok(data);
                }
                else return Ok("查無此人");
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

        //Edit Emp
        [Route("Update")]
        [HttpPost]
        public IActionResult Edit([FromBody] Input edit)
        {
            try
            {
                var check = _context.Employee.Where(x => x.EmpNo == edit.id);
                if (check == null)
                {
                    return Ok("查無此人");
                }
                else
                {
                    var updata = new string[6] { edit.id, edit.name, edit.sex, edit.dept, edit.payment, edit.bday };
                    var updateStr = _context.Employee.AsQueryable();
                    if (edit.name != null || edit.sex != null || edit.dept != null || edit.payment != null || edit.bday!=null)
                    {
                        updateStr.Where(x => x.EmpNo == updata[0]).FirstOrDefault().EmpName = updata[1];
                        updateStr.Where(x => x.EmpNo == updata[0]).FirstOrDefault().Sex = updata[2];
                        updateStr.Where(x => x.EmpNo == updata[0]).FirstOrDefault().DeptNo = updata[3];
                        updateStr.Where(x => x.EmpNo == updata[0]).FirstOrDefault().Salary = Int32.Parse(updata[4]);
                        updateStr.Where(x => x.EmpNo == updata[0]).FirstOrDefault().Brithday = updata[5];
                        _context.Employee.UpdateRange(updateStr);
                        _context.SaveChanges();
                        var data = _context.Employee.ToList();
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

        //Estimate Salary
        //Helper: SalaryHelper

        public class Input {
            public string id { get; set; }
            public string name { get; set; }

            public string sex { get; set; }
            public string dept { get; set; }
            public string payment { get; set; }
            public string bday { get; set; } 
        }
    }
}
