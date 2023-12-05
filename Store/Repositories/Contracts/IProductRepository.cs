namespace Repositories.Contracts;

using System.Collections.Generic;
using Entities.Models;

public interface IProductRepository
    : IRepositoryBase<Product>
{
    IQueryable<Product> GetAllProductsWithDetails();
}