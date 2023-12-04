using System.Linq.Expressions;
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

    public T? Read(Expression<Func<T, bool>> filter)
    {
        return _context
            .Set<T>()
            .SingleOrDefault(filter);
    }

    public List<T> ReadAll(Expression<Func<T, bool>> filter = null)
    {
        return filter is null
          ? _context.Set<T>().ToList()
          : _context.Set<T>().Where(filter).ToList();
    }

    public void Update(T item)
    {
        _context.Set<T>().Update(item);
        // _context.SaveChanges();
    }
}
