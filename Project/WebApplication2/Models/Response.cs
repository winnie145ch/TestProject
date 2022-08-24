using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Response
    {
        public dynamic Result { get; set; }
        public string Message { get; set; }
        public string ReturnCode { get; set; }
        public bool Success { get; set; }

        public Response(object result)
        {
            Message = "SUCCESS";
            ReturnCode = "200";
            Success = true;
            Result = result;
        }
        public Response(Exception ex)
        {
            Message = "FAIL: "+ ex.Message;
            ReturnCode = "500";
            Success = false;
            Result = ex;
        }
    }
}
