using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Repositories.Abstract;
using SportsStore.Models;

namespace SportsStore.Controllers;

public class OrderController : Controller
{
    private readonly Cart _cart;
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repoService, Cart cartService)
    {
        _repository = repoService;
        _cart = cartService;
    }

    public ViewResult Checkout()
    {
        return View(new Order());
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (_cart.Lines.Count == 0)
            ModelState.AddModelError("", "Sorry, your cart is empty!");

        // ModelState is a property of the Controller base class that provides access to the ModelStateDictionary object.
        if (!ModelState.IsValid)
            return View();

        // Used ToArray() to ensure that the reference to the cart lines is copied, rather than the lines themselves.
        order.Lines = _cart.Lines.ToArray();
        _repository.SaveOrder(order);

        _cart.Clear();
        return RedirectToPage("/Completed", new { orderId = order.OrderId });
    }
}