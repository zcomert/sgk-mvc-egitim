using Microsoft.AspNetCore.Mvc;
using StoreApi.InMemoryRepositories;
using StoreApi.Models;

namespace StoreApi.Controllers;

[ApiController]
[Route("api/booksfake")]
public class BooksFakeController : ControllerBase
{
    private readonly BookRepositoryFake _fakeBookRepositoy;

    public BooksFakeController(BookRepositoryFake fakeBookRepositoy)
    {
        _fakeBookRepositoy = fakeBookRepositoy;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        try
        {
            return Ok(_fakeBookRepositoy.Books);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        try
        {
            return Ok(_fakeBookRepositoy.GetOne(id));
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _fakeBookRepositoy.Add(book);
                return Created($"/api/books/{book.Id}", book);
            }
            return BadRequest(ModelState);

        }
        catch (System.Exception)
        {
            throw;
        }

    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
    [FromBody] Book book)
    {
        try
        {
            if (ModelState.IsValid)
            {
                return Ok(_fakeBookRepositoy.UpdateBook(id, book));
            }
            return BadRequest(ModelState);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpDelete]
    public IActionResult DeleteAll()
    {
        try
        {
            _fakeBookRepositoy.DeleteAll();
            return NoContent(); // 204
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
    {
        try
        {
            _fakeBookRepositoy.DeleteOne(id);
            return NoContent(); // 204
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}