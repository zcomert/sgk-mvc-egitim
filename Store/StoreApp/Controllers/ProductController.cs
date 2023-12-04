using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers;

public class ProductController : Controller
{
    private readonly IRepositoryManager _manager;

    public ProductController(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        List<Product>? products = _manager.ProductRepository.ReadAll();
        return View(products);
    }

    public IActionResult Get(int id)
    {
        var product = _manager.ProductRepository
        .Read(p => p.ProductId.Equals(id));
        return View(product);
    }
    public IActionResult Create()
    {
        ViewBag.Categories = GetCategorySelectList();
        return View();
    }

    private SelectList GetCategorySelectList()
    {
        // Categories sayfaya gitmeli.
        var categories = _manager
        .CategoryRepository
        .ReadAll();

        return new SelectList(categories,
        "CategoryId",
        "CategoryName",
        "1");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Product model)
    {
        _manager.ProductRepository.Create(model);
        _manager.Save();
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        ViewBag.Categories = GetCategorySelectList();
        
        var prd = _manager
        .ProductRepository
        .Read(prd => prd.ProductId.Equals(id));

        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Product model)
    {
        _manager
        .ProductRepository
        .Update(model);

        _manager.Save();

        return RedirectToAction("Index");
    }

    public IActionResult Delete([FromRoute] int id)
    {
        var prd = _manager
        .ProductRepository
        .Read(prd => prd.ProductId.Equals(id));

        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromForm] Product model)
    {
        _manager
        .ProductRepository
        .Delete(model);

        return RedirectToAction("Index");
    }
}