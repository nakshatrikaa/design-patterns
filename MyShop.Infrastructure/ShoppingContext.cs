using Microsoft.EntityFrameworkCore;
using MyShop.Domain;

namespace MyShop.Infrastructure;

public sealed class ShoppingContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=orders.db");
    }

    public ShoppingContext()
    {
        Database.EnsureCreated();
    }
}