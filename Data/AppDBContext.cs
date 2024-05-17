
using Microsoft.EntityFrameworkCore;
using TestApp.Models;
using RecruitmentFormCreator.Models;

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

            modelBuilder.Entity<ApplicationForm>()
                .ToContainer("ApplicationForms")
                .HasPartitionKey(a => a.Id)
                .HasNoDiscriminator();

            modelBuilder.Entity<Question>()
                .ToContainer("Questions")
                .HasPartitionKey(q => q.Id)
                .HasNoDiscriminator();

            modelBuilder.Entity<ApplicationSubmission>()
                .ToContainer("ApplicationSubmissions")
                .HasPartitionKey(x => x.Id)
                .HasNoDiscriminator();


            modelBuilder.Entity<ApplicationForm>()
                .HasMany(p => p.Questions)
                .WithOne(q => q.ApplicationForm)
                .HasForeignKey(q => q.ApplicationFormId);

        }
        public DbSet<ApplicationForm> ApplicationForms { get; set; } = default!;
        public DbSet<Question> Questions { get; set; } = default!;
        public DbSet<ApplicationSubmission> ApplicationSubmission { get; set; } = default!;
    }
}
