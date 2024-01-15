using Microsoft.EntityFrameworkCore;
using platforma.Models.Domain;

namespace platforma.Data
{
    public class PlatformaDbContext : DbContext
    {
        public PlatformaDbContext(DbContextOptions<PlatformaDbContext> options) : base(options)
        {
        }

        public DbSet<PostAnimal> PostAnimals { get; set; }
        public DbSet<Animal> Animals { get; set; }
    }
}
