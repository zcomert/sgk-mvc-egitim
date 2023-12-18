using Microsoft.AspNetCore.Mvc;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    // ./api/books
    [HttpGet]
    public String Greeting()
    {
        return "Merhaba ASP.NET Core Web API.";
    }

    // api/books/{name}
    [HttpGet("{name}")]
    public String Greeting(string name)
    {
        return $"Merhaba {name}";
    }
}