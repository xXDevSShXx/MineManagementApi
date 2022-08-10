using Microsoft.EntityFrameworkCore;

namespace MineManagementApi.Models
{
    public class MineManagementApiDbContext : DbContext
    {
        public MineManagementApiDbContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
