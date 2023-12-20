using SportsStore.Models;

namespace SportsStore.Data.Repositories.Abstract;

// Interface defining the contract for a repository that provides access to a collection of products.
public interface IStoreRepository
{
    IQueryable<Product> Products { get; }
    void SaveProduct(Product p);        
    void CreateProduct(Product p);        
    void DeleteProduct(Product p);
}