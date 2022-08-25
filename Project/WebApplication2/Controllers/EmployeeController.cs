using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Helpers;
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

        public DateTime localtime = DateTime.Now;
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
        [Route("Salary")]
        [HttpGet]
        public IActionResult Cal(string id, int time) {
            try
            {
                SalaryHelper salary = new SalaryHelper();
                var check = _context.Employee.Where(x => x.EmpNo == id);
                if (check == null)
                {
                    return Ok("查無此人");
                }
                else {
                    var search = _context.Employee.Where(x => x.EmpNo == id).Join(_context.Employee,
                        x => x.EmpNo,
                        y => y.EmpNo,
                        (x, y) => new
                        {
                            Name = x.EmpName,
                            Salary = x.Salary,
                            //照年資計算:year(now datetime - birthday)-25(統一入職年齡)=入職年資
                            //未來薪資:入職年資 + 預計time年 = (para)years => 直接加上去當加薪
                            Future = salary.CalcuSalary(x.Sex, x.DeptNo, (localtime - Convert.ToDateTime($"{x.Brithday.Substring(0, 4) }+,+{x.Brithday.Substring(4, 2)} +,+ {x.Brithday.Substring(6, 2)}")).Days / 365 + time, x.Salary, Int32.Parse(_claim._config.Plus))
                        }).FirstOrDefault();
                        return Ok(search);
                }
            }
            catch (Exception ex)
            {
                return Ok(new Response(ex));
                throw;
            }
        }

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
