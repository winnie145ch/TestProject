using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject_220804.Controllers
{
    [Route("api/Client")]
    public class ClientController : APIControllerBase
    {
        // GET: api/Client
        //Client_GET
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://10.11.24.95/SinoCloud.Service/Service/GetTopic/117892/Test/2020-06-12/2020-11-18");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return Ok(responseBody);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Client_POST
        [HttpPost("Post")]
        public async Task<IActionResult> Post() {
            try
            {
                var client = new HttpClient();
                var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Route", "Service/GetTopic/117889/Test/2020-06-24/2020-11-24"),
                new KeyValuePair<string, string>("HttpMethod","GET"),
                new KeyValuePair<string, string>("body","{}")
            });
                client.DefaultRequestHeaders.Add("token","3333");
                var result = await client.PostAsync("http://10.11.24.95/gateway.org/Route", content);
                if (result.IsSuccessStatusCode)
                {
                    var text = await result.Content.ReadAsStringAsync();
                    return Ok(text);
                }
                else return Ok("Failure");                    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
