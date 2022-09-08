using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Services;

namespace WebApplication2.Helpers
{
    public class SalaryHelper
    {
        public SalaryHelper()
        {
        }

        public int CalcuSalary(string sex, string dept, int year, int salary, int bonus) {

            //deal with DeptNo string char convert to number
            var output = 0;
            var type = dept.Substring(4, 1);
            var code = System.Text.Encoding.Unicode.GetBytes(type);
            string result = String.Format("{0:X}", code[1]) + String.Format("{0:X}", code[0]);
            try
            {
                output = Int32.Parse(result);
            }
            catch (Exception)
            {
                var ex = result.Substring(2, 1);
                var subCode = System.Text.Encoding.Unicode.GetBytes(ex);
                string result2 = String.Format("{0:X}", subCode[1]) + String.Format("{0:X}", subCode[0]);
                output = Int32.Parse(result.Substring(0, 2) + result2);
            }

            // real salary calculate
            if (salary >= 25000 && year > 1)
            {
                if (sex == "F") { salary += (bonus + 500) * year; }
                else salary += bonus * year;
                if (output % 2 == 1) salary = Convert.ToInt32(salary * 1.2);
            }
            else if (salary >= 25000 && year <= 1) salary = salary;
            else salary = 25000;
            return salary;
        }
    }
}
