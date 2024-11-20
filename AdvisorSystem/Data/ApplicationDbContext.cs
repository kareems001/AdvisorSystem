using Microsoft.EntityFrameworkCore;
using AdvisorSystem.Models; // Replace with the actual namespace of your models

namespace AdvisorSystem.Data // Replace with your desired namespace
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet for Advisors
        public DbSet<Advisor> Advisors { get; set; }

        // Seed data for testing
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Advisor entity
            modelBuilder.Entity<Advisor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.FullName).HasMaxLength(255).IsRequired();
                entity.Property(a => a.SIN).HasMaxLength(9).IsRequired();
                entity.HasIndex(a => a.SIN).IsUnique(); // Unique constraint
                entity.Property(a => a.Address).HasMaxLength(255);
                entity.Property(a => a.PhoneNumber).HasMaxLength(10);
                entity.Property(a => a.HealthStatus).IsRequired();
            });          
        }
    }
}
