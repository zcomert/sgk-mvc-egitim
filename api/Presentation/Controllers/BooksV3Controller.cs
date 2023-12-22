using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Presentation.Controllers;


[ApiController]
[Route("api/books")]
public class BooksV3Controller : ControllerBase
{
    private readonly IRepositoryManager _manager;

    public BooksV3Controller(IRepositoryManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var model = _manager
        .BookRepository
        .ReadAll();

        return Ok(model);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
    {
        var model = _manager
            .BookRepository
            .Read(b => b.Id.Equals(id), false);
        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateOneBook([FromBody] Book book)
    {
        if (book is null)
            return BadRequest(); // 400 
        _manager
            .BookRepository
            .Create(book);

        _manager.Save();

        return CreatedAtAction(nameof(GetOneBook), new { id = book.Id }, book);
        //return StatusCode(201, book);
    }

    [HttpPut("{id:int}")]
    // api/books?id={id} şeklindeki endpoint üzerinden gücelleme alır.
    public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
        [FromBody] Book book)
    {
        // Emin ol kitap var mı?
        var entity = _manager
            .BookRepository
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
        _manager
            .BookRepository
            .Update(book);

        _manager.Save();

        return Ok(book);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
    {
        // varlıktan emin olmalıyız.
        var entity = _manager
                .BookRepository
                .Read(b => b.Id.Equals(id), false);

        if (entity is null)
            throw new BookNotFoundException(1);

        _manager
            .BookRepository
            .Delete(entity);

        _manager.Save();

        return NoContent(); // 204
    }
}