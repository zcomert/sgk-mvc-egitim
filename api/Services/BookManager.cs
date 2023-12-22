using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using Entities.Exceptions;

namespace Services;

public class BookManager : IBookService
{
    private readonly IRepositoryManager _manager;

    public BookManager(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public Book CreateOneBook(Book book)
    {
        if (book is null)
            throw new Exception("Kitap nesnesi boş olamaz!");

        _manager.BookRepository.Create(book);
        _manager.Save();
        return book;
    }

    public void DeleteOneBook(int id)
    {
        var book = GetOneBook(id, false);
        _manager.BookRepository.Delete(book);
        _manager.Save();
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _manager
            .BookRepository
            .ReadAll();
    }

    public Book GetOneBook(int id, bool trackChanges)
    {
        var book = _manager
            .BookRepository
            .Read(b => b.Id.Equals(id), false);

        if (book is null)
            throw new BookNotFoundException(id);

        return book;
    }

    public Book UpdateOneBook(int id, Book book)
    {
        throw new NotImplementedException();
    }
};