using CodeChallenge1.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge1.DbContexts
{
    public class UserInfoContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserInfoContext(DbContextOptions<UserInfoContext> options) : base(options)
        {

        }
    }
}
