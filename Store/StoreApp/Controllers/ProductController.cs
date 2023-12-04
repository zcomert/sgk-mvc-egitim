using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

namespace StoreApp.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repository;
    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        List<Product>? products = _repository.ReadAll();
        return View(products);
    }

    public IActionResult Get(int id)
    {
        var product = _repository
        .Read(p => p.ProductId.Equals(id));
        return View(product);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] Product model)
    {
        _repository.Create(model);
        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var prd = _repository.Read(prd => prd.ProductId.Equals(id));
        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(Product model)
    {
        _repository.Update(model);
        return RedirectToAction("Index");
    }

    public IActionResult Delete([FromRoute] int id)
    {
        var prd = _repository.Read(prd => prd.ProductId.Equals(id));
        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromForm] Product model)
    {
        _repository.Delete(model);
        return RedirectToAction("Index");
    }
}