using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers;

public class HomeController : Controller
{
    private readonly IStoreRepository _repository;
    public int PageSize = 4;

    public HomeController(IStoreRepository repo)
    {
        _repository = repo;
    }

    public ViewResult Index(string? category, int productPage = 1)
    {
        var model = new ProductsListViewModel
        {
            Products = _repository.Products
                .Where(p => string.IsNullOrEmpty(category) || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = string.IsNullOrEmpty(category)
                    ? _repository.Products.Count()
                    : _repository.Products.Count(e => e.Category == category)
            },
            CurrentCategory = category
        };
        return View(model);
    }
}