using System.Linq.Expressions;
using Entities.Models;

namespace Services.Contracts;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts(Expression<Func<Product, bool>> filter = null);
    Product? GetOneProduct(int id);
    void CreateOneProduct(Product product);
    void UpdateOneProduct(int id, Product product);
    void DeleteOneProduct(int id);
}
