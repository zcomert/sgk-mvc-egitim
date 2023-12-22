using Entities.Models;

namespace Services.Contracts;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book GetOneBook(int id, bool trackChanges);
    Book CreateOneBook(Book book);
    Book UpdateOneBook(int id, Book book);
    void DeleteOneBook(int id);
}