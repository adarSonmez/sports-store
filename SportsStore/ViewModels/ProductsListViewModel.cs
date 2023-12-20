using SportsStore.Models;

namespace SportsStore.ViewModels;

// View model class representing data for displaying a list of products in a view.
public class ProductsListViewModel
{
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

    public PagingInfo PagingInfo { get; set; } = new();

    public string? CurrentCategory { get; set; }
}