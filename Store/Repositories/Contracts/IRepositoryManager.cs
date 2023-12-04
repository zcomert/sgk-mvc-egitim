namespace Repositories.Contracts;

public interface IRepositoryManager
{
    public IProductRepository ProductRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
}