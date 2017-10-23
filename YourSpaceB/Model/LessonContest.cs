using Microsoft.EntityFrameworkCore;
namespace YourSpaceB
{
    public class LessonContext : DbContext
    {
        public LessonContext(DbContextOptions<LessonContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}