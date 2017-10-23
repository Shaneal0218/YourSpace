using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourSpaceB.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly LessonContext _context;
        public UsersController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
            if (_context.Users.Count() == 0)
            {
                User user1 = new User();
                user1.Id = 1;
                user1.Username = "b00oo00m3r4ng";
                user1.Firstname = "Shaneal";
                user1.Lastname = "Prasad";
                user1.Email = "shanealp@uci.edu";
                user1.Password = "shaneal";
                user1.ProfilePic = "https://static-resource.np.community.playstation.net/avatar/3RD/30004.png";
                user1.Online = false;
                user1.Friends = new List<User>();
                user1.Notifications = new List<Notification>();
                user1.Favorites = new List<Favorite>();
                user1.AboutMe = "Full Stack Software Developer that enjoys conquering unique problems using technologies like HTML, CSS,Javascript, jQuery, Bootstrap, AngularJS, C# , ASP.NET, and Entity Framework.";

                User user2 = new User();
                user2.Id = 2;
                user2.Username = "CHAKA_CHAKA";
                user2.Firstname = "Chance";
                user2.Lastname = "Hernandez";
                user2.Email = "chanceh@uci.edu";
                user2.Password = "chance";
                user2.ProfilePic = "http://www.psnleaderboard.com/images/avatars/E0004.png";
                user2.Online = false;
                user2.Friends = new List<User>();
                user2.Notifications = new List<Notification>();
                user2.Favorites = new List<Favorite>();
                user2.AboutMe = "I am a full stack developer with experience working with: Front end technologies such as HTML, CSS, and JavaScript | Back end technologies such as C#, ASP.NET and SQL | Frameworks such as Bootstrap, jQuery, and AngularJS";

                User user3 = new User();
                user3.Id = 3;
                user3.Username = "Brian";
                user3.Firstname = "Brian";
                user3.Lastname = "canlas";
                user3.Email = "bcanlas@gmail.com";
                user3.Password = "foxtrot";
                user3.ProfilePic = "http://www.psnleaderboard.com/images/avatars/E0004.png";
                user3.Online = false;
                user3.Friends = new List<User>();
                user3.Notifications = new List<Notification>();
                user3.Favorites = new List<Favorite>();
                user3.AboutMe = "I am a Fullstack Developer with experience in working with front end technologies: HTML, CSS, Bootsrap, JavaScript, jQuery, AngularJS, and React. As well as experience in back end technologies: C#, ASP.NET, Node.Js , Restful API's, Mongo DB, and SQL Server.";

                _context.Users.Add(user1);
                _context.Users.Add(user2);
                _context.Users.Add(user3);
                _context.SaveChanges();
            }
        }
        // GET api/values
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.Include("Friends").Include("Notifications").Include("Favorites.video.snippet").ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            foreach (User user in _context.Users.Include("Friends").Include("Notifications").Include("Favorites.video.snippet").ToList())
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User value)
        {
            value.Id = _context.Users.Count() + 1;
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]User value)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == value.Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            _context.Users.Add(value);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (User user in _context.Users)
            {
                if (user.Id == id)
                {
                    if(user.Id == id)
                    {
                        _context.Users.Remove(user);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
