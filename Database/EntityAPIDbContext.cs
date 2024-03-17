using Microsoft.EntityFrameworkCore;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Database
{
    public class EntityAPIDbContext : DbContext
    {
        public EntityAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entity> Entities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Names)
                .WithOne()
                .HasForeignKey(name => name.EntityId);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Dates)
                .WithOne()
                .HasForeignKey(date => date.EntityId);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Addresses)
                .WithOne()
                .HasForeignKey(address => address.EntityId);
        }
    }
}
