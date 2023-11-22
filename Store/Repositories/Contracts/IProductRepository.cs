namespace Repositories.Contracts;
using Entities.Models;

public interface IProductRepository
{
    int Count { get; }
    void Create(Product item);
    void Update(int id, Product item);
    void Delete(int id);
    Product? Read(int id);
    List<Product> ReadAll();
}