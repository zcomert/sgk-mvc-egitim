using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Presentation.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly RepositoryContext _context;

    public BooksController(RepositoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var model = _context.Books;
        return Ok(model);
    }
}