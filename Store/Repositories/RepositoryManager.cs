using Repositories.Contracts;

namespace Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public RepositoryManager(IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public IProductRepository ProductRepository => _productRepository;
    public ICategoryRepository CategoryRepository => _categoryRepository;

    public void Save()
    {
        throw new NotImplementedException();
    }
}