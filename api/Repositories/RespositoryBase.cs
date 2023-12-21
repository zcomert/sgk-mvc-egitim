using System.Linq.Expressions;
using Repositories.Contracts;

namespace Repositories;

public class RespositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    private readonly RepositoryContext _context;

    public RespositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public T? Read(Expression<Func<T, bool>> filter, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public IQueryable<T>? ReadAll(Expression<Func<T, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}
