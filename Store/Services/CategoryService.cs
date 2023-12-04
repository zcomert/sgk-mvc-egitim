using System.Linq.Expressions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _manager;

    public CategoryService(IRepositoryManager manager)
    {
        _manager = manager;
    }

    public IEnumerable<Category> GetAllCategories(Expression<Func<Category, bool>> filter = null)
    {
        return _manager
        .CategoryRepository
        .ReadAll();
    }

    public Category? GetOneCategory(int id)
    {
        return _manager
        .CategoryRepository
        .Read(c => c.CategoryId.Equals(id));
    }
}