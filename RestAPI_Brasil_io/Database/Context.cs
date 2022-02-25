using Microsoft.EntityFrameworkCore;
using RestAPI_Brasil_io.Models;

namespace RestAPI_Brasil_io.Database
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
