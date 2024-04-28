
using Microsoft.EntityFrameworkCore;
using GreenGardens.Model;
using AddToTable.Model;

namespace GreenGardens.Data
{
    public class AppDbContext : DbContext
    {
        // Define a DbSet for TaskModel. This represents the Tasks table in the database.
        public DbSet<product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<customer> Users { get; set; }
        public DbSet<order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // Constructor for the AppDbContext, receiving DbContextOptions of AppDbContext type.
        // It passes these options to the base DbContext class.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // The base constructor handles the options.
        }
    }
}
