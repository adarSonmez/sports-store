using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers;

public class HomeController : Controller
{
    public int PageSize = 4;
    private readonly IStoreRepository _repository;

    public HomeController(IStoreRepository repo)
    {
        _repository = repo;
    }

    public ViewResult Index(int productPage = 1)
    {
        var model = new ProductsListViewModel
        {
            Products = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _repository.Products.Count()
            }
        };
        return View(model);
    }
}