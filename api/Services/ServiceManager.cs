using Services.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly IBookService _bookService;

    public ServiceManager(IBookService bookService)
    {
        _bookService = bookService;
    }

    public IBookService BookService =>
        _bookService;
}
