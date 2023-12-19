using Microsoft.AspNetCore.Mvc;
using StoreApi.InMemoryRepositories;

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
        return Ok(_fakeBookRepositoy.Books);
    }
}