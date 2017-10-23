using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace YourSpaceB.Controllers
{
    [Route("api/[controller]")]
    public class EntertainmentController : Controller
    {
        // GET api/entertainment
        [HttpGet]
        public async Task<IActionResult> GetNews() 
        {
            using ( var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://newsapi.org");
                    var response = await client.GetAsync("/v1/articles?source=entertainment-weekly&sortBy=top&apiKey=43b4b5eff75e438cb1d80023e0882fe4");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var myResponse = JsonConvert.DeserializeObject<EntertainmentRootObject>(stringResult);
                    return Ok(myResponse);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting videos from Youtube: {httpRequestException.Message}");
                }
            }
        }
    }
}
