
using Microsoft.EntityFrameworkCore;
using GreenGardens.Model;

namespace GreenGardens.Data
{
    public class AppDbContext : DbContext
    {
        // Define a DbSet for TaskModel. This represents the Tasks table in the database.
        public DbSet<product> product { get; set; }
        public DbSet<customer> customer { get; set; }
        public DbSet<admin> admin { get; set; }
        public DbSet<order> order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<order>()
                .HasKey(cs => new { cs.productId, cs.customerId });

            modelBuilder.Entity<order>()
                .HasOne(cs => cs.customer)
                .WithMany(s => s.Orders)
                .HasForeignKey(cs => cs.customerId);

            modelBuilder.Entity<order>()
                .HasOne(cs => cs.product)
                .WithMany(c => c.Orders)
                .HasForeignKey(cs => cs.productId);
        }

        // Constructor for the AppDbContext, receiving DbContextOptions of AppDbContext type.
        // It passes these options to the base DbContext class.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // The base constructor handles the options.
        }
    }
}
