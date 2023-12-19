namespace Entities.Exceptions;

public class BookNotFoundException : NotFoundExceptions
{
    public BookNotFoundException(int id) 
        : base($"Book with id :{id} could not found.")
    {

    }
}
