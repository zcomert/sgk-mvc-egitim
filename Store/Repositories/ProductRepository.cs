using System.Linq.Expressions;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RepositoryContext _context;

        public ProductRepository(RepositoryContext context)
        {
            _context = context;
        }

        public int Count => _context.Products.Count();
        public void Create(Product item)
        {
            _context.Products.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Product item)
        {
            _context.Products.Remove(item);
            _context.SaveChanges();
        }

        public Product? Read(Expression<Func<Product, bool>> filter)
        {
            return _context
            .Products
            .SingleOrDefault(filter);
        }

        public List<Product> ReadAll(Expression<Func<Product, bool>> filter = null)
        {
            return filter is null
            ? _context.Products.ToList()
            : _context.Products.Where(filter).ToList();
        }

        public void Update(Product item)
        {
            _context.Products.Update(item);
            _context.SaveChanges();
        }
    }
}