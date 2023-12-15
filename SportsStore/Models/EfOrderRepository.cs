using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models;

// Entity Framework-based implementation of the IOrderRepository interface.
public class EfOrderRepository : IOrderRepository {
    // Database context for accessing the underlying database.
    private readonly StoreDbContext _context;

    // Constructor to inject the StoreDbContext dependency.
    public EfOrderRepository(StoreDbContext ctx) {
        _context = ctx;
    }

    // Queryable collection of orders provided by the Entity Framework context.
    public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Product);

    // Method to save an order to the database.
    public void SaveOrder(Order order) {
        _context.AttachRange(order.Lines.Select(l => l.Product));
        if (order.OrderId == 0) {
            _context.Orders.Add(order);
        }
        _context.SaveChanges();
    }
}