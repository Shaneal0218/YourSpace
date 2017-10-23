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
    public class VideoController : Controller
    {
        private readonly LessonContext _context;
        public VideoController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // GET api/video
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> Video(string videoId)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // b4ozdiGys5g
                    client.BaseAddress = new Uri("https://www.googleapis.com");
                    var response = await client.GetAsync($"/youtube/v3/videos?id={videoId}&part=snippet&key=AIzaSyB9BnIJt1Y1aKgxjFr8bniwrp6KGxmFdwM");
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine(videoId);

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var myResponse = JsonConvert.DeserializeObject<VideoRootObject>(stringResult);
                    Console.WriteLine(myResponse);
                    return Ok(myResponse);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting videos from Youtube: {httpRequestException.Message}");
                }
            }
        }
        [Route("api/[controller]/favorite/add")]
        [HttpPost]
        public void PostFavoriteVideo([FromBody]FavoriteRequest request)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == request.user.Id);

            Favorite favorite = new Favorite();
            favorite.video = request.video;

            if (user.Favorites == null)
            {
                user.Favorites = new List<Favorite>();
            }
            user.Favorites.Add(favorite);
            _context.SaveChanges();
        }

        [Route("api/[controller]/share")]
        [HttpPost]
        public void PostSharedVideo([FromBody]Notification request)
        {
            request.RequestType = "SV";
            
            User toUser = _context.Users.FirstOrDefault(u => u.Id == request.User.Id);
            User fromUser = _context.Users.FirstOrDefault(u => u.Username == request.fromUser);
            if (toUser.Notifications == null)
            {
                toUser.Notifications = new List<Notification>();
            }
            request.fromUser = fromUser.Username;
            toUser.Notifications.Add(request);
            _context.SaveChanges();
        }
    }
}