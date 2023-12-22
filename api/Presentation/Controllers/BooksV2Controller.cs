using Entities.Exceptions;
using Entities.Models;
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
        var model = _bookRepository.Read(b => b.Id.Equals(id), false);
        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        if (book is null)
            return BadRequest(); // 400 
        _bookRepository.Create(book);
        return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
        //return StatusCode(201, book);
    }

    [HttpPut]
    public IActionResult UpdateOneBook([FromQuery(Name = "id")] int id,
        [FromBody] Book book)
    {
        // Emin ol kitap var mı?
        var entity = _bookRepository
            .Read(b => b.Id.Equals(id), false);

        if (entity is null)
            throw new BookNotFoundException(id);

        // gövde (MessageBody) geçerli mi?
        if (book is null)
            return UnprocessableEntity();

        // id ile book.Id 
        if (!id.Equals(book.Id))
            return BadRequest();

        // Varsa güncelle
        _bookRepository.Update(book);
        return Ok(book);
    }
}
