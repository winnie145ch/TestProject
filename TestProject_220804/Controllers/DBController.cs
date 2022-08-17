using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

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

        //SqlConnection
        [HttpGet("sqlconnection")]
        public ActionResult Conn() {
            string Connection = "Data Source=10.11.37.148;Initial Catalog=TrainDB120999;Persist Security Info=True;User ID=120999;Password=120999";
            string stat = "Select * From Employee Where Salary >= 75000 Order By Salary Desc";
            try
            {
                List<string> result = new List<string>();
                using ( var conn = new SqlConnection(Connection)) {
                    SqlCommand command = new SqlCommand(stat, conn);
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            result.Add(reader.GetString(0));
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
