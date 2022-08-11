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
        private ClaimAccessor _claim;
        private ClaimSetting _claimsetting;
        public ValueController(ClaimAccessor claim, ClaimSetting claimsetting) {
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


        public IHeaderDictionary _Headers => _claim._accessor?.HttpContext?.Request?.Headers;
        [Route("request")]
        [HttpGet]
        public IActionResult Header() {
            try
            {
                return Ok(_Headers);
            }
            catch {
                throw;
            }
        }

        public string RemoteIp => _claim._accessor?.HttpContext?.Connection.RemoteIpAddress.ToString();
        [Route("request/ip")]
        [HttpGet]
        public IActionResult Ip() {
            try
            {
#if DEBUG
        var word = " ; Meow ᓚᘏᗢ";
#else
        var word = " ; Woff UʘᴥʘU";
#endif
                return Ok(RemoteIp + word);
            }
            catch
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
