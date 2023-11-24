using System.Linq.Expressions;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryBase<T> : IRepositoryBase<T>
where T : class
{
    private readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public int Count => _context.Set<T>().Count();

    public void Create(T item)
    {
        throw new NotImplementedException();
    }

    public void Delete(T item)
    {
        throw new NotImplementedException();
    }

    public T? Read(Expression<Func<T, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<T> ReadAll(Expression<Func<T, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(T item)
    {
        throw new NotImplementedException();
    }
}
