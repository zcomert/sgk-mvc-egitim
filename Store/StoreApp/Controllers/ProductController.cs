using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers;

public class ProductController : Controller
{
    private readonly IServiceManager _manager;

    public ProductController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var products = _manager
            .ProductService
            .GetAllProducts();

        return View(products);
    }

    public IActionResult Get(int id)
    {
        var product = _manager
            .ProductService
            .GetOneProduct(id, false);

        return View(product);
    }
    public IActionResult Create()
    {
        ViewBag.Categories = GetCategorySelectList();
        return View(new Product()
        {
            ProductName = "Ürünü adını giriniz"
        });
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