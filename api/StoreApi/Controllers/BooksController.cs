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
        InMemoryBookRepository.DeleteOne(id);
        return NoContent(); // 204
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
    [FromBody] Book book)
    {
        Book? updatedBook = InMemoryBookRepository.UpdateBook(id, book);
        return Ok(updatedBook);
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
        try
        {
            return Ok(InMemoryBookRepository.Books);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute] int id)
    {
        try
        {
            var book = InMemoryBookRepository.GetOne(id);
            if (book is null)
            {
                throw new Exception($"Book with id:{id} not found.");
            }
            return Ok(book);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
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