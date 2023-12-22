using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IBookRepository _bookRepository;
    private readonly RepositoryContext _context;

    public RepositoryManager(IBookRepository bookRepository, 
        RepositoryContext context)
    {
        _bookRepository = bookRepository;
        _context = context;
    }

    public IBookRepository BookRepository =>
        _bookRepository;

    public void Save()
    {
        _context.SaveChanges();
    }
}
