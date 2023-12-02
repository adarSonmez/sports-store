using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages;

// Razor Pages model for managing the shopping cart.
public class CartModel : PageModel
{
    private IStoreRepository _repository;

    public CartModel(IStoreRepository repo)
    {
        _repository = repo;
    }

    public Cart? Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    // Handler method for handling HTTP GET requests.
    public void OnGet(string? returnUrl)
    {
        // Set the return URL and retrieve the cart data from the session.
        ReturnUrl = returnUrl ?? "/";
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
    }

    // Handler method for handling HTTP POST requests when adding items to the cart.
    public IActionResult OnPost(long productId, string returnUrl)
    {
        // Retrieve the product based on the provided productId.
        var product = _repository.Products
            .FirstOrDefault(p => p.ProductId == productId);

        if (product == null) return RedirectToPage(new { returnUrl });

        // If the product exists, update the cart and store it in the session.
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        Cart.AddItem(product, 1);
        HttpContext.Session.SetJson("cart", Cart);

        // Redirect to the specified return URL.
        return RedirectToPage(new { returnUrl });
    }
}