using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

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
    }

    public IEnumerable<Book> GetAllBooks()
    {
        throw new NotImplementedException();
    }

    public Book GetOneBook(int id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Book UpdateOneBook(int id, Book book)
    {
        throw new NotImplementedException();
    }
}