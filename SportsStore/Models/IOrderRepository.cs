namespace SportsStore.Models;

// Interface defining the contract for a repository that provides access to a collection of orders.
public interface IOrderRepository {

    IQueryable<Order> Orders { get; }
    void SaveOrder(Order order);
}