using Microsoft.EntityFrameworkCore;
using domain.Materials;

namespace persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Concrete> Concrete { get; set; }
        public DbSet<Steel> Steel { get; set; }
    }
}