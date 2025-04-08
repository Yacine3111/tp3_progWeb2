using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var generator = new DataGenerator();
            generator.SeedEverything(modelBuilder);
        }
    }
}
