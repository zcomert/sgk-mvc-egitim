using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IBookRepository _bookRepository;

    public RepositoryManager(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public IBookRepository BookRepository =>
        _bookRepository;

    public void Save()
    {
        throw new NotImplementedException();
    }
}
