namespace SportsStore.Models;

// Interface defining the contract for a repository that provides access to a collection of products.
public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
}