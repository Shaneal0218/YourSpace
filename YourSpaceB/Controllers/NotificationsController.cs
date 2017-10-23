using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourSpaceB.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly LessonContext _context;
        public NotificationsController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        [Route("api/notifications/directmessage")]
        [HttpPost]
        public void PostDirectMessage([FromBody]Notification message)
        {
            message.RequestType = "DM";
            message.Pending = true;
            User fromUser = _context.Users.FirstOrDefault(u => u.Id == message.User.Id);
            User toUser = _context.Users.FirstOrDefault(u => u.Username == message.fromUser);
            if (toUser.Notifications == null)
            {
                toUser.Notifications = new List<Notification>();
            }
            message.fromUser = fromUser.Username;
            toUser.Notifications.Add(message);
            _context.SaveChanges();
        }

        [Route("api/notifications/friendrequest")]
        [HttpPost]
        public void PostFriendRequest([FromBody]Notification message)
        {
            message.RequestType = "FR";
            message.Pending = true;

            User fromUser = _context.Users.FirstOrDefault(u => u.Id == message.User.Id);
            User toUser = _context.Users.FirstOrDefault(u => u.Username == message.fromUser);

            if (toUser.Notifications == null)
            {
                toUser.Notifications = new List<Notification>();
            }
            
            message.fromUser = fromUser.Username;
            toUser.Notifications.Add(message);
            _context.SaveChanges();
        }
    }
}