using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context)
        : base(context)
        {

        }

        public IQueryable<Product> GetAllProductsWithDetails()
        {

            // var query = from product in _context.Products
            //             join category in _context.Categories on product.CategoryId equals category.CategoryId into productCategory
            //             from category in productCategory.DefaultIfEmpty()
            //             select new
            //             {
            //                 ProductId = product.ProductId,
            //                 ProductName = product.ProductName,
            //                 Price = product.Price,
            //                 Category = category
            //             };

            // var result = query.ToList();


            return _context
                .Products
                .Include(p => p.Category);
        }
    }
}