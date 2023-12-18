using Microsoft.AspNetCore.Mvc;
using StoreApi.InMemoryRepositories;
using StoreApi.Models;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    [HttpDelete]
    public IActionResult DeleteAllBooks()
    {
        return NoContent(); // 204
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
    {
        return NoContent(); // 204
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
    [FromBody] Book book)
    {
        return Ok(book);
    }


    [HttpPost] // api/books
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        try
        {
            InMemoryBookRepository.Add(book);
            return Created($"api/books/{book.Id}", book);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var model = new List<Book>()
        {
            new Book(){Id=1, Title="Olasılıksız", Price=125},
            new Book(){Id=2, Title="Mesnevi", Price=225},
            new Book(){Id=3, Title="İnsan ve Fare", Price=25}
        };

        return Ok(model);
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
    [HttpGet("{name}")]
    public String Greeting([FromRoute] string name)
    {
        return $"Merhaba {name}";
    }
}