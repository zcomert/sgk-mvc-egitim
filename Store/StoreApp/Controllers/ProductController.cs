using Entities.Dtos;
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

}