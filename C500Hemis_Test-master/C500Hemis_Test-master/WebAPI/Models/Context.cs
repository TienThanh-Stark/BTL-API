using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<human> humans { get; set; }
    }
}
