using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Repositories.Abstract;
using SportsStore.Models;

namespace SportsStore.Components;

// View component providing data for the navigation menu.
public class NavigationMenuViewComponent : ViewComponent
{
    private readonly IStoreRepository _repository;

    public NavigationMenuViewComponent(IStoreRepository repo)
    {
        _repository = repo;
    }

    // Method invoked when rendering the view component.
    public IViewComponentResult Invoke()
    {
        // Set the selected category in the ViewBag for use in the view.
        ViewBag.SelectedCategory = RouteData?.Values["category"] ?? string.Empty;

        // Retrieve and return a sorted list of distinct product categories.
        return View(
            _repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
        );
    }
}