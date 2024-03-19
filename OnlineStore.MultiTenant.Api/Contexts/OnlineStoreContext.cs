using Microsoft.EntityFrameworkCore;
using OnlineStore.MultiTenant.Api.Models;
using System.Security.Cryptography.X509Certificates;

namespace OnlineStore.MultiTenant.Api.Contexts
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext(DbContextOptions<OnlineStoreContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = Guid.NewGuid(), Name = "Vintage Typewriter", Description = "A vintage typewriter for the nostalgic writer.", Price = 120.0m },
                new Product { ProductId = Guid.NewGuid(), Name = "Leather Notebook", Description = "A handcrafted leather notebook for your thoughts.", Price = 45.0m },
                new Product { ProductId = Guid.NewGuid(), Name = "Wooden Desk Lamp", Description = "A stylish wooden desk lamp for your workspace.", Price = 80.0m }
            );

            // Seed Orders
            var order1Id = Guid.NewGuid();
            var order2Id = Guid.NewGuid();

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = order1Id, CustomerId = Guid.NewGuid(), CreationDate = DateTime.Now },
                new Order { Id = order2Id, CustomerId = Guid.NewGuid(), CreationDate = DateTime.Now }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 1, Price = 120.0m, WeightInKg = 3.5m },
                new OrderItem { OrderItemId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 2, Price = 45.0m, WeightInKg = 0.5m },
                new OrderItem { OrderItemId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 1, Price = 80.0m, WeightInKg = 1.0m }
            );
        }
    }
}
