using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

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

    public void OnGet()
    {

    }

    public IActionResult OnPost([FromForm] int productId, string returnUrl)
    {
        var prd = _manager
            .ProductService
            .GetOneProduct(productId, false);

        Cart.AddItem(prd);

        // ?returnUrl=...
        return RedirectToPage(new { ReturnUrl = returnUrl });
    }
}