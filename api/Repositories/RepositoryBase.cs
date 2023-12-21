using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
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
        return trackChanges
            ? _context.Set<T>().Where(filter).SingleOrDefault()
            : _context.Set<T>().Where(filter).AsNoTracking().SingleOrDefault();
    }

    public IQueryable<T>? ReadAll(Expression<Func<T, bool>> filter = null)
    {
        return filter is null
            ? _context.Set<T>()
            : _context.Set<T>().Where(filter);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }
}
