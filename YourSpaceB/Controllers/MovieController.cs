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
  public class MovieController : Controller
  {
    [HttpGet]
    public async Task<IActionResult> GetMovies()
    {
      using (var client = new HttpClient())
      {
        try
        {
          client.BaseAddress = new Uri("https://api.themoviedb.org");
          var response = await client.GetAsync("/3/movie/now_playing?api_key=643770daba26a5454996321497367f1c&language=en-US&page=1");
          response.EnsureSuccessStatusCode();

          var stringResult = await response.Content.ReadAsStringAsync();
          var myResponse = JsonConvert.DeserializeObject<MovieRootObject>(stringResult);
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