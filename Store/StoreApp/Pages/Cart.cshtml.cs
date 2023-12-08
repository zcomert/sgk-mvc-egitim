using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages;

public class CartModel : PageModel
{
    private readonly IServiceManager _manager;
    public Cart Cart { get; set; }
    public String? ReturnUrl { get; set; } = "/";

    public CartModel(Cart cart, IServiceManager manager)
    {
        Cart = cart;
        _manager = manager;
    }

    public void OnGet(string returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
        Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
    }

    public IActionResult OnPost([FromForm] int productId,
        [FromForm] string returnUrl)
    {
        var prd = _manager
            .ProductService
            .GetOneProduct(productId, false);

        // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        Cart.AddItem(prd);
        // HttpContext.Session.SetJson<Cart>("cart", Cart);

        // ?returnUrl=...
        return RedirectToPage(new { ReturnUrl = returnUrl });
    }

    public IActionResult OnPostRemove([FromForm] int productId)
    {
        var prd = _manager
        .ProductService
        .GetOneProduct(productId);

        // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        Cart.RemoveLine(prd);
        // HttpContext.Session.SetJson<Cart>("cart", Cart);

        return Page();
    }
}