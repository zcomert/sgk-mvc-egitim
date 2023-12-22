using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BooksV4Controller : ControllerBase
{
    private readonly IServiceManager _manager;

    public BooksV4Controller(IServiceManager manager)
    {
        _manager = manager;
    }


    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var model = _manager
        .BookService
        .GetAllBooks();

        return Ok(model);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        var model = _manager
            .BookService
            .GetOneBook(id,false);
        
        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        _manager
            .BookService
            .CreateOneBook(book);

        return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
    }
}
