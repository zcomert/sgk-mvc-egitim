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
        var book = _books
            .SingleOrDefault(b => b.Id.Equals(id));
        if (book is null)
            throw new Exception($"Book nok found: Id : {id}");
        return book;
    }

    public static Book UpdateBook(int id, Book book)
    {
        // kitap gerçekten var mı?
        var entity = GetOne(id);

        if (!book.Id.Equals(id))
            throw new Exception("Ids could not been matched.");

        entity.Title = book.Title;
        entity.Price = book.Price;

        return entity;
    }

    public static void DeleteOne(int id)
    {
        var book = GetOne(id);
        _books.Remove(book);
    }
}