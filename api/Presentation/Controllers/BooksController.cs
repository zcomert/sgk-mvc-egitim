using Entities.Exceptions;
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
        try
        {
            var model = _context.Books;
            return Ok(model);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetOneBook(int id)
    {
        try
        {
            var model = _context
                        .Books
                        .SingleOrDefault(b => b.Id.Equals(id));

            if (model is null)
                throw new BookNotFoundException(id); // 400
            
            return Ok(200);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}