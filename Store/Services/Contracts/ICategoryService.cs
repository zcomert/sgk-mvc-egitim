using System.Linq.Expressions;
using Entities.Models;

namespace Services.Contracts;

public interface ICategoryService
{
    IEnumerable<Category> GetAllCategories(Expression<Func<Category,bool>> filter=null);
    Category? GetOneCategory(int id);
}
