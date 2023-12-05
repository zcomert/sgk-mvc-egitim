using System.Linq.Expressions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ProductService : IProductService
{
    private readonly IRepositoryManager _manager;

    public ProductService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public void CreateOneProduct(Product product)
    {
        _manager.ProductRepository.Create(product);
        _manager.Save();
    }

    public void DeleteOneProduct(int id)
    {
        var product = GetOneProduct(id);
        _manager.ProductRepository.Delete(product);
        _manager.Save();
    }

    public IEnumerable<Product> GetAllProducts(Expression<Func<Product, bool>> filter = null,
        bool isTracking = false)
    {
        return _manager
                .ProductRepository
                .ReadAll(filter,isTracking);
    }

    public Product? GetOneProduct(int id, bool isTracking=true)
    {
        var product = _manager
                    .ProductRepository
                    .Read(prd => prd.ProductId.Equals(id), isTracking);
        
        if (product is null)
            throw new Exception();

        return product;
    }

    public void UpdateOneProduct(int id, Product product)
    {
        var prd = GetOneProduct(id,false); // tracking ProductId
        _manager.ProductRepository.Update(product);
        _manager.Save();
        // if (id.Equals(product.ProductId))
        // {
        //     prd.ProductName = product.ProductName;
        //     prd.Price = product.Price;

        //     _manager.ProductRepository.Update(prd);
        //     _manager.Save();
        // }
    }
}