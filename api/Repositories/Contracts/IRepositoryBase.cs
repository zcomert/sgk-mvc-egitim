using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
    // CRUD
    void Create(T entity);
    T? Read(Expression<Func<T, bool>> filter, bool trackChanges);
    IQueryable<T>? ReadAll(Expression<Func<T, bool>> filter=null);
    void Update(T entity);
    void Delete(T entity);
}
