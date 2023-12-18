using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{

    [HttpGet]
    public List<Book> GetAllBooks()
    {
        return new List<Book>()
        {
            new Book(){Id=1, Title="Olasılıksız", Price=125},
            new Book(){Id=2, Title="Mesnevi", Price=225},
            new Book(){Id=3, Title="İnsan ve Fare", Price=25}
        };
    }

    [HttpGet("{id:int}")]
    public Book GetOneBook([FromRoute] int id)
    {
        return new Book()
        {
            Id = id,
            Title = "Devlet",
            Price = 100
        };
    }

    // ./api/books
    [HttpGet]
    [Route("greetings")]
    public String Greeting()
    {
        return "Merhaba ASP.NET Core Web API.";
    }

    // api/books/{name}
    [HttpGet("{name:string}")]
    public String Greeting([FromRoute] string name)
    {
        return $"Merhaba {name}";
    }
}