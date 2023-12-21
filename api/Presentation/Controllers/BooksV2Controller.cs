using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BooksV2Controller : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    public BooksV2Controller(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var model = _bookRepository
        .ReadAll()
        .Select(b => new
        {
            Title = b.Title,
            Price = b.Price
        });
        return Ok(model);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        var model = _bookRepository.Read(b => b.Id.Equals(id));
        return Ok(model);
    }
}
