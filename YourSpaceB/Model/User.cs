using System.Collections.Generic;
namespace YourSpaceB
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePic { get; set; }
        public bool Online { get; set; }
        public List<User> Friends { get; set; }
        public List<Notification> Notifications { get; set; }
        public List<Favorite> Favorites { get; set; }
        public string AboutMe { get; set; }
    }
}