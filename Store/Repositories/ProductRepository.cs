using Entities.Models;

namespace Repositories
{
    public class ProductRepository
    {
        private List<Product> productList;
        public ProductRepository()
        {
            productList = new List<Product>()
            {
                new Product(){ProductId=1, ProductName="Computer", Price=30_000},
                new Product(){ProductId=2, ProductName="Phone", Price=40_000},
            };
        }
        public int Count => productList.Count();

        public void Create(Product item)
        {
            productList.Add(item);
        }

        public void Update(int id, Product item)
        {
            foreach (var prd in productList)
            {
                if(prd.ProductId.Equals(id))
                {
                    prd.ProductName = item.ProductName;
                    prd.Price = item.Price;
                    return;
                }
            }
        }

        public void Delete(int id)
        {
            foreach (Product prd in productList)
            {
                if(prd.ProductId.Equals(id))
                {
                    productList.Remove(prd);
                    return;
                }
            }
        }

        public Product? Read(int id)
        {
            foreach (var prd in productList)
            {
                if(prd.ProductId.Equals(id))
                {
                    return prd;
                }
            }
            return null;
        } 

        public List<Product> ReadAll() 
        {
            return productList;
        }
    }
}