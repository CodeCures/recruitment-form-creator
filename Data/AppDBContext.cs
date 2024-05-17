
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
                .HasPartitionKey(c => c.Id)
                .HasNoDiscriminator();

            modelBuilder.Entity<Question>()
                .ToContainer("Questions")
                .HasPartitionKey(q => q.Id)
                .HasNoDiscriminator();


            modelBuilder.Entity<AppProgram>()
                .HasMany(p => p.Questions)
                .WithOne(q => q.AppProgram)
                .HasForeignKey(q => q.AppProgramId);
        }
        public DbSet<AppProgram> Programs { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
    }
}
