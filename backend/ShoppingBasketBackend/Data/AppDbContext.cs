using Microsoft.EntityFrameworkCore;
using ShoppingBasketBackend.Models;

namespace ShoppingBasketBackend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Define the Products table
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed the Products table with initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Soup", Price = 0.65M },
                new Product { Id = 2, Name = "Bread", Price = 0.80M },
                new Product { Id = 3, Name = "Milk", Price = 1.30M },
                new Product { Id = 4, Name = "Apples", Price = 1.00M }
            );
        }
    }
}
