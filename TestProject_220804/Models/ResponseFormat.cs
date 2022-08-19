using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject_220804.Models
{
    public class ResponseFormat
    {
        public object Result { get; set; }
        public string Message { get; set; }
        public string ReturnCode { get; set; }
        public bool Success { get; set; }

        public ResponseFormat(object result) {
            Result = result;
            Message = "SUCCESS";
            ReturnCode = "200";
            Success = true;
        }

        public ResponseFormat(Exception ex) {
            Result = ex;
            Message = "FAILURE";
            ReturnCode = "500";
            Success = false;
        }
    }
}
