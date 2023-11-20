using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicApp.Models;

namespace BasicApp.Controllers;

public class HomeController : Controller
{
    public String Hello()
    {
        return "Hello MVC.";
    }

    public List<String> Names()
    {
        var names = new List<String>(){
            "Ahmet",
            "Mehmet",
            "Can"
        };
        return names;
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
