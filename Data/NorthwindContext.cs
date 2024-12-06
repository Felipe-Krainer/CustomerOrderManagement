using Microsoft.EntityFrameworkCore;
using CustomerOrderManagement.Models;

namespace CustomerOrderManagement.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        // DbSets for tables
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map the primary key for Customers
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);

            // Map the primary key for Orders
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderID);

            // Foreign key relationship: Orders -> Customers
            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerID);

            // Map the primary key for Products
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductID);
        }
    }
}
