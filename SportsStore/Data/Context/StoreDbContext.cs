using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

namespace SportsStore.Data.Context;

// Database context class for interacting with the underlying database.
public class StoreDbContext : DbContext
{
    // Constructor that accepts DbContextOptions for configuring the context.
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<Order> Orders => Set<Order>();
}