namespace SportsStore.Models;

public class EfStoreRepository : IStoreRepository
{
    private readonly StoreDbContext _context;

    public EfStoreRepository(StoreDbContext ctx)
    {
        _context = ctx;
    }

    public IQueryable<Product> Products => _context.Products;
}