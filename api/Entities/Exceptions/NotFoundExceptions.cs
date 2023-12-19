namespace Entities.Exceptions;

public abstract class NotFoundExceptions : Exception
{
    public NotFoundExceptions(string message) 
        : base(message)
    {
        
    }
}