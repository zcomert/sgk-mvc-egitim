using Entities.Exceptions;
using Entities.Models;
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
        throw new Exception("HataAA!!!!");
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
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        try
        {
            var model = _context
                        .Books
                        .SingleOrDefault(b => b.Id.Equals(id));

            if (model is null)
                throw new BookNotFoundException(id); // 400

            return Ok(model);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        try
        {
            if (book is null)
                return BadRequest();

            _context.Books.Add(book);
            _context.SaveChanges();

            return Created($"/api/books/{book.Id}", book);
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
            if (!id.Equals(book.Id))
                return BadRequest(); // 400

            if (book is null)
                return UnprocessableEntity(); // 422

            _context.Books.Update(book);
            _context.SaveChanges();
            return Ok(book);    // 200

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
            var book = _context
                    .Books
                    .SingleOrDefault(b => b.Id.Equals(id));

            if (book is null)
                throw new BookNotFoundException(id); // 404

            _context.Remove(book);
            _context.SaveChanges();
            return NoContent(); // 204
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
            _context.Books.RemoveRange(_context.Books.ToArray());
            _context.SaveChanges();
            return NoContent(); // 204
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}