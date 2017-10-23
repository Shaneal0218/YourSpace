using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourSpaceB.Controllers
{
    public class AccountController : Controller
    {
        private readonly LessonContext _context;
        public AccountController(LessonContext context)
        {
            _context = context;
        }

        [Route("api/account/signout")]
        [HttpPost]
        public void PostLogOut([FromBody]User currentUser)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == currentUser.Username);
            user.Online = false;
            _context.SaveChanges();
        }

        [Route("api/account/signin")]
        [HttpPost]
        public User PostLogIn([FromBody]User currentUser)
        {
            User user = _context.Users.Include("Friends").Include("Notifications").FirstOrDefault(u => u.Username == currentUser.Username && u.Password == currentUser.Password);

            if (user != null)
            {
                user.Online = true;
                _context.SaveChanges();
            }
            return user;
        }
    }
}