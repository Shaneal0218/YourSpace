using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace YourSpaceB.Controllers
{  
    public class FriendRequestController : Controller
    {
        private readonly LessonContext _context;
        public FriendRequestController(LessonContext context)
        {
            _context = context;
            _context.SaveChanges();
        }
        // POST api/values
        [Route("api/[controller]/accept")]
        [HttpPost]
        public void PostAcceptFriendRequest([FromBody]Notification accept)
        {
            
            User user1 = _context.Users.Include("Notifications").Include("Friends").FirstOrDefault(u => u.Id == accept.User.Id);
            User user2 = _context.Users.Include("Notifications").Include("Friends").FirstOrDefault(u => u.Username == accept.fromUser);

            foreach (Notification x in user1.Notifications)
            {
                if (x.Id == accept.Id)
                {
                    x.Pending = false;
                }
            }

            Notification accepted = new Notification();
            accepted.fromUser = user1.Username;
            accepted.RequestType = "AcceptedFR";
            accepted.User = user2;
            user2.Notifications.Add(accepted);
            
            if (user1.Friends == null)
            {
                user1.Friends = new List<User>();
            }
            if (user2.Friends == null)
            {
                user2.Friends = new List<User>();
            }
            
            user1.Friends.Add(user2);
            user2.Friends.Add(user1);
            _context.SaveChanges();
        }
    }
}