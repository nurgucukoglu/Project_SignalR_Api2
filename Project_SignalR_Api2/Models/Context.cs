using Microsoft.EntityFrameworkCore;

namespace Project_SignalR_Api2.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Electric> Electrics { get; set; }
    }
}
