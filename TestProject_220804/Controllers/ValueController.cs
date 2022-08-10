using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestProject_220804.Services;

namespace TestProject_220804.Controllers
{
    [Produces("application/json")]
    [Route("api/value")]
    public class ValueController : Controller
    {
        private Claim _claim;
        private ClaimSetting _claimsetting;
        public ValueController(Claim claim, ClaimSetting claimsetting) {
            _claim = claim;
            _claimsetting = claimsetting;
        }
        [HttpGet]
        public IActionResult Get1() {
            try
            {
                return Ok(_claim._config.Language);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get2(int id)
        {
            try
            {
                return Ok(_claimsetting._config.Default_lang);
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        //程式範例
        /*[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }*/
    }
}
