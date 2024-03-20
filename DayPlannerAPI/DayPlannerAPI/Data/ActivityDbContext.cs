using DayPlannerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DayPlannerAPI.Data
{
    public class ActivityDbContext : DbContext
    {
        public ActivityDbContext(DbContextOptions<ActivityDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PlannedActivity> PlannedActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlannedActivity>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlannedActivities)
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            // Remove cascade delete behavior
            modelBuilder.Entity<PlannedActivity>()
                .HasOne(p => p.User)
                .WithMany(u => u.PlannedActivities)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
