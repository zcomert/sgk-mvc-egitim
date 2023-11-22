using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicApp.Models;

namespace BasicApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Hello()
    {
        string message = $"Hello MVC {DateTime.Now.ToString()}";
        return View("Hello", message);
    }

    public IActionResult Names()
    {
        var names = new List<String>(){
            "Ahmet",
            "Mehmet",
            "Can"
        };
        return View(model: names);
    }

    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
