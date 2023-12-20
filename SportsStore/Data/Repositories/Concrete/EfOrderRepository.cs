using Microsoft.EntityFrameworkCore;
using SportsStore.Data.Context;
using SportsStore.Data.Repositories.Abstract;
using SportsStore.Models;

namespace SportsStore.Data.Repositories.Concrete;

// Entity Framework-based implementation of the IOrderRepository interface.
public class EfOrderRepository : IOrderRepository
{
    private readonly StoreDbContext _context;

    // Constructor to inject the StoreDbContext dependency.
    public EfOrderRepository(StoreDbContext ctx)
    {
        _context = ctx;
    }

    // IQueryable collection of orders obtained from the Entity Framework context.
    // We use eager loading to include the Product entities associated with each OrderLine. 
    public IQueryable<Order> Orders => _context.Orders
        .Include(o => o.Lines) 
        .ThenInclude(l => l.Product);

    // SaveOrder method is responsible for persisting an order to the database.
    public void SaveOrder(Order order)
    {
        // Attach the products associated with each order line to the context.
        // This ensures that Entity Framework is aware of these entities when saving changes.
        _context.AttachRange(order.Lines.Select(l => l.Product));

        // If the OrderId is 0, it indicates a new order that hasn't been added to the database.
        if (order.OrderId == 0)
            _context.Orders.Add(order);

        // Save changes to the database.
        _context.SaveChanges();
    }
}