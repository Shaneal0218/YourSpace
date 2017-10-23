using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourSpaceB.Controllers
{
    public class DeleteFriendController : Controller
    {
        private readonly LessonContext _context;
        public DeleteFriendController(LessonContext context)
        {
            _context = context;
        }

        [Route("api/[controller]")]
        [HttpPost]
        public void PostDeleteFriend([FromBody]Notification request)
        {
            User fromUser = _context.Users.FirstOrDefault(u => u.Id == request.User.Id);
            User toUser = _context.Users.FirstOrDefault(u => u.Username == request.fromUser);
            fromUser.Friends.Remove(toUser);
            toUser.Friends.Remove(fromUser);
            _context.SaveChanges();
        }
    }
}