using Entities.Models;
using Repositories.Contracts;

namespace Repositories;
public class DynamicProductRepository : IProductRepository
{
    private LinkedList<Product> productList;
    public int Count => throw new NotImplementedException();

    public DynamicProductRepository()
    {
        productList = new LinkedList<Product>();
        productList.AddFirst(new Product() { ProductId = 1, ProductName = "Computer", Price = 30_000 });
        productList.AddFirst(new Product() { ProductId = 2, ProductName = "Phone", Price = 40_000 });
    }

    public void Create(Product item)
    {
        productList.AddFirst(item);
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Product? Read(int id)
    {
        throw new NotImplementedException();
    }

    public List<Product> ReadAll()
    {
        return productList.ToList();
    }

    public void Update(int id, Product item)
    {
        throw new NotImplementedException();
    }
}