
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppProgram>()
                .ToContainer("Programs")
                .HasPartitionKey(c => c.Id);
        }
        public DbSet<AppProgram> Programs { get; set; } = default!;
    }
}
