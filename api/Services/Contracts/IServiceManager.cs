using Services.Contracts;

namespace Services;

public interface IServiceManager
{
    IBookService BookService { get; }
}
