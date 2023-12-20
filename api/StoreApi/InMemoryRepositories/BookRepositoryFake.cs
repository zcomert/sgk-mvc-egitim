using Entities.Exceptions;
using Entities.Models;

namespace StoreApi.InMemoryRepositories;

public class BookRepositoryFake 
{
    public IEnumerable<Book> Books => _books;
    private List<Book> _books;
    public BookRepositoryFake()
    {
        _books = new List<Book>();
    }

    public void Add(Book book)
    {
        _books.Add(book);
    }

    public Book? GetOne(int id)
    {
        var book = _books
            .SingleOrDefault(b => b.Id.Equals(id));
        if (book is null)
            throw new BookNotFoundException(id);
        return book;
    }

    public Book UpdateBook(int id, Book book)
    {
        // kitap gerçekten var mı?
        var entity = GetOne(id);

        if (!book.Id.Equals(id))
            throw new Exception("Ids could not been matched.");

        entity.Title = book.Title;
        entity.Price = book.Price;

        return entity;
    }

    public void DeleteOne(int id)
    {
        var book = GetOne(id);
        _books.Remove(book);
    }
    public void DeleteAll()
    {
        _books.Clear();
    }
}