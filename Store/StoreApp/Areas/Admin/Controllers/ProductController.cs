using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers;


[Area("Admin")]
public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var model = _manager
            .ProductService
            .GetAllProductsWithDetails();

        return View(model);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = GetCategorySelectList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Product model)
    {
        _manager
        .ProductService
        .CreateOneProduct(model);
        return RedirectToAction("Index");
    }
    private SelectList GetCategorySelectList()
    {
        // Categories sayfaya gitmeli.
        var categories = _manager
        .CategoryService
        .GetAllCategories();

        return new SelectList(categories,
        "CategoryId",
        "CategoryName",
        "1");
    }
}