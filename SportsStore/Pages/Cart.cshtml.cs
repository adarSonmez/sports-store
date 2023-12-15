using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Models;

namespace SportsStore.Pages
{
    // CartModel class represents the Razor Page model for managing the shopping cart.
    public class CartModel : PageModel
    {
        private IStoreRepository _repository;

        // Constructor to initialize the model with a repository and the Cart service.
        public CartModel(IStoreRepository repo, Cart cartService)
        {
            _repository = repo;
            Cart = cartService;
        }

        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; } = "/";

        // Handler for the HTTP GET request to the Cart page, allowing specification of a return URL.
        public void OnGet(string? returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        // Handler for the HTTP POST request to add a product to the cart.
        public IActionResult OnPost(long productId, string returnUrl)
        {
            var product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null) Cart.AddItem(product, 1);

            return RedirectToPage(new { returnUrl });
        }

        // Handler for the HTTP POST request to remove a product from the cart.
        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Product.ProductId == productId).Product);

            return RedirectToPage(new { returnUrl });
        }
    }
}
