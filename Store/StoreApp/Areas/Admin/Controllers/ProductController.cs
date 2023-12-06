using System.ComponentModel.DataAnnotations;
using Entities.Dtos;
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
    public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion model, IFormFile file)
    {
        ViewBag.Categories = GetCategorySelectList();

        if (ModelState.IsValid)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            model.ImageUrl = String.Concat("/images/", file.FileName);

            _manager
            .ProductService
            .CreateOneProduct(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult Update(int id)
    {
        ViewBag.Categories = GetCategorySelectList();

        var prd = _manager
            .ProductService
            .GetOneProductDtoForUpdate(id, false);

        return View(prd);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(ProductDtoForUpdate model)
    {
        ViewBag.Categories = GetCategorySelectList();

        if (ModelState.IsValid)
        {
            _manager
                .ProductService
                .UpdateOneProduct(model.ProductId, model);

            return RedirectToAction("Index");
        }

        return View(model);
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