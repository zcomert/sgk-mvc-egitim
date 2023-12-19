using StoreApi.Models;

namespace StoreApi.InMemoryRepositories;

public static class InMemoryBookRepository
{
    public static IEnumerable<Book> Books => _books;
    private static List<Book> _books;
    static InMemoryBookRepository()
    {
        _books = new List<Book>();
    }

    public static void Add(Book book)
    {
        _books.Add(book);
    }

    public static Book? GetOne(int id)
    {
        return _books
            .SingleOrDefault(b => b.Id.Equals(id));
    }

    public static Book UpdateBook(int id, Book book)
    {
        // kitap gerçekten var mı?
        // varsa güncelle yoksa hata fırlat!
    }
}