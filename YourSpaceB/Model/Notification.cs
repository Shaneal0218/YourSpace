using System.Collections.Generic;
namespace YourSpaceB
{
    public class Notification
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string fromUser { get; set; }
        public string RequestType { get; set; }
        public bool Read { get; set; }
        public bool Pending { get; set; }
        public string Message { get; set; }
        public string videoId { get; set; }
    }
}