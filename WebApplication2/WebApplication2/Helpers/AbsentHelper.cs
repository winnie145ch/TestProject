using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers
{
    public class AbsentHelper
    {
        //check offical
        public bool OfficalAvailable(string sex, string dept, int past, int envOff)
        {
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

            // start absent calculate
            if (output % 2 == 1)
            {
                envOff += 3;
                if (sex == "F") envOff += 1;
            }
            else
            {
                envOff += 1;
                if (sex == "F") envOff += 1;
            }

            if (past < envOff) return true;
            else return false;
        }

        //check sick
        public bool SickAvailable(string sex, string dept, int past, int envSick)
        {
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

            // start absent calculate
            if (output % 2 == 1)
            {
                envSick += 2;
                if (sex == "F") envSick += 1;
            }
            else
            {
                envSick += 1;
                if (sex == "F") envSick += 1;
            }

            if (past < envSick) return true;
            else return false;
        }

        //search absent in the past
        public string Search(string sex, string dept, int pastOff, int pastSick, int envOff, int envSick) {
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


            if (output % 2 == 1)
            {
                envOff += 3;
                envSick += 2;
                if (sex == "F")
                {
                    envOff += 1;
                    envSick += 1;
                }
            }
            else
            {
                envOff += 1;
                envSick += 1;
                if (sex == "F")
                {
                    envOff += 1;
                    envSick += 1;
                }
            }

            if (pastOff > envOff)
            {
                if (pastSick > envSick)
                    return $"公假 : {envOff}，已請公假 : {pastOff}。病假 : {envSick}，已請病假 : {pastSick}。※公假額度已滿，若有需求請呈上級協議。 ※也請注意身體健康。";
                else return $"公假 : {envOff}，已請公假 : {pastOff}。病假 : {envSick}，已請病假 : {pastSick}。 ※公假額度已滿，若有需求請呈上級協議。";
            }
            else {
                if(pastSick > envSick) return $"公假 : {envOff}，已請公假 : {pastOff}。病假 : {envSick}，已請病假 : {pastSick}。 ※請注意身體健康。";
                else return $"公假 : {envOff}，已請公假 : {pastOff}。病假 : {envSick}，已請病假 : {pastSick}。";
            }
        }
    }
}

