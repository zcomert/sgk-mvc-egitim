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
        return Ok(_bookRepository.ReadAll());
    }
}
