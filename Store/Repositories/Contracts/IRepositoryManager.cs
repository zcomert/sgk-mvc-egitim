namespace Repositories.Contracts;

public interface IRepositoryManager
{
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    void Save();
}