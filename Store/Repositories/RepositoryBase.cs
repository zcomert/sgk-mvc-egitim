using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
where T : class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public int Count => _context.Set<T>().Count();

    public void Create(T item)
    {
        _context.Set<T>().Add(item);
        // _context.SaveChanges();
    }

    public void Delete(T item)
    {
        _context.Set<T>().Remove(item);
        // _context.SaveChanges();
    }

    public T? Read(Expression<Func<T, bool>> filter, bool isTracking = true)
    {
        return isTracking
        ? _context
            .Set<T>()
            .SingleOrDefault(filter)
        : _context
            .Set<T>()
            .AsNoTracking()
            .SingleOrDefault(filter);
    }

    public IQueryable<T> ReadAll(Expression<Func<T, bool>> filter = null, 
        bool isTracking = false)
    {
        return isTracking
          ? filter is null
            ? _context.Set<T>()
            : _context.Set<T>().Where(filter)

          : filter is null
            ? _context.Set<T>().AsNoTracking()
            : _context.Set<T>().Where(filter).AsNoTracking();
    }

    public void Update(T item)
    {
        _context.Set<T>().Update(item);
        // _context.SaveChanges();
    }
}
