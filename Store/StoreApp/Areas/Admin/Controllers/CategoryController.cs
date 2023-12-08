namespace StoreApp.Areas.Admin.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

[Area("Admin")]
// [Authorize(Roles = "Admin")]
public class CategoryController : Controller
{
    private readonly IServiceManager _manager;

    public CategoryController(IServiceManager manager)
    {
        _manager = manager;
    }

    public IActionResult Index()
    {
        var data = _manager
            .CategoryService
            .GetAllCategories();
        return View(data);
    }
}