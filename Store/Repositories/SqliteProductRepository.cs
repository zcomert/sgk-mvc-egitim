using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class SqliteProductRepository : IProductRepository
    {
        private readonly RepositoryContext _context;

        public SqliteProductRepository(RepositoryContext context)
        {
            _context = context;
        }

        public int Count => throw new NotImplementedException();

        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var prd = Read(id);
            _context.Products.Remove(prd);
            _context.SaveChanges();
        }

        public Product? Read(int id)
        {
            return _context
            .Products
            .SingleOrDefault(prd => prd.ProductId.Equals(id));
        }

        public List<Product> ReadAll()
        {
            return _context.Products.ToList();
        }

        public void Update(int id, Product item)
        {
            throw new NotImplementedException();
        }
    }
}