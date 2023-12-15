using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models;

// Database context class for interacting with the underlying database.
public class StoreDbContext : DbContext
{
    // Constructor that accepts DbContextOptions for configuring the context.
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    // DbSet representing the collection of Product entities in the database.
    public DbSet<Product> Products => Set<Product>();

    // DbSet representing the collection of Order entities in the database.
    public DbSet<Order> Orders => Set<Order>();
}