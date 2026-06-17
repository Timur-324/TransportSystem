using Microsoft.EntityFrameworkCore;
using TransportServer.Models;

namespace TransportServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Repair> Repairs { get; set; }
    }
}