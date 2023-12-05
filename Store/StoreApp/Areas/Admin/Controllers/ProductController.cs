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

    public IActionResult Update(int id)
    {
        ViewBag.Categories = GetCategorySelectList();

        var prd = _manager
            .ProductService
            .GetOneProduct(id, false);

        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Product model)
    {
        _manager
            .ProductService
            .UpdateOneProduct(model.ProductId, model);

        return RedirectToAction("Index");
    }

    public IActionResult Delete([FromRoute] int id)
    {
        var prd = _manager
            .ProductService
            .GetOneProduct(id);

        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromForm] Product model)
    {
        _manager
        .ProductService
        .DeleteOneProduct(model.ProductId);

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