using System.Linq.Expressions;

namespace Repositories.Contracts;

public interface IRepositoryBase<T>
{
    int Count { get; }
    void Create(T item);
    void Update(T item);
    void Delete(T item);
    T? Read(Expression<Func<T, bool>> filter);
    List<T> ReadAll(Expression<Func<T, bool>> filter = null);
}
