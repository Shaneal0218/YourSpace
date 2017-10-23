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
    public class TrendingController : Controller
    {
        // GET api/trending
        [HttpGet]
        public async Task<IActionResult> Trending() 
        {
            using ( var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://www.googleapis.com");
                    var response = await client.GetAsync("/youtube/v3/videos?&part=snippet&key=AIzaSyB9BnIJt1Y1aKgxjFr8bniwrp6KGxmFdwM&maxResults=8&chart=mostPopular");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var myResponse = JsonConvert.DeserializeObject<TrendingRootObject>(stringResult);
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