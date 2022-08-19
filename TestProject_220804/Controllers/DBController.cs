using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;

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
        public class Employee
        {
            public string EmpNo { get; set; }
            public string EmpName { get; set; }
            public string Sex { get; set; }
            public string DeptNo { get; set; }
            public int Salary { get; set; }
            public string Birthday { get; set; }
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

        //SqlConnection
        [HttpGet("sqlconnection")]
        public ActionResult Conn() {
            string Connection = "Data Source=10.11.37.148;Initial Catalog=TrainDB120999;Persist Security Info=True;User ID=120999;Password=120999";
            string stat = "Select * From Employee Where Salary >= 75000 Order By Salary Desc";
            try
            {
                List<string> result = new List<string>();
                //List<List<string>> data = new List<List<string>>();
                Employee data = new Employee();
                using ( var conn = new SqlConnection(Connection)) {
                    SqlCommand command = new SqlCommand(stat, conn);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                             result.Add($"員工編號: {reader.GetString(0)}");//EmpNo
                             result.Add($"姓名: {reader.GetString(1)}");//EmpName
                             result.Add($"性別: {reader.GetString(2)}");//Sex
                             result.Add($"科別: {reader.GetString(3)}");//DeptNo
                             result.Add($"薪水: {reader.GetInt32(4).ToString()}");//Salary
                             result.Add($"生日: {reader.GetString(5)}");//Birthday
                            
                            /*data = new Employee()
                            {
                                EmpNo = reader.GetString(1),
                                EmpName = reader.GetString(2),
                                Sex = reader.GetString(3),
                                DeptNo = reader.GetString(4),
                                Salary = reader.GetInt32(5),
                                Birthday = reader.GetString(6)
                            };
                            */
                        }
                    }
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }         
    }
}
