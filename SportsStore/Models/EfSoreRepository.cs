namespace SportsStore.Models;

// Entity Framework-based implementation of the IStoreRepository interface.
public class EfStoreRepository : IStoreRepository
{
    private readonly StoreDbContext _context;

    // Constructor to inject the StoreDbContext dependency.
    public EfStoreRepository(StoreDbContext ctx)
    {
        _context = ctx;
    }

    // Queryable collection of products provided by the Entity Framework context.
    public IQueryable<Product> Products => _context.Products;
}