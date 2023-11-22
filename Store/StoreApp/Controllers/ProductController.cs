using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace StoreApp.Controllers;

public class ProductController : Controller
{
    private readonly ProductRepository _repository;

    public ProductController(ProductRepository repository)
    {
        _repository = repository; // resolve
    }

    public IActionResult Index()
    {
        List<Product>? products = _repository.ReadAll();
        return View(products);
    }

    public IActionResult Get(int id)
    {
        var product = _repository.Read(id);
        return View(product);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Product model)
    {
        _repository.Create(model);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var prd = _repository.Read(id);
        return View(prd);
    }
}