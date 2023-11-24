using System.Linq.Expressions;
using Entities.Models;
using Repositories.Contracts;

namespace Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RepositoryContext _context;

    public CategoryRepository(RepositoryContext context)
    {
        _context = context;
    }

    public int Count => _context.Categories.Count();

    public void Create(Category item)
    {
        _context.Categories.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Category item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public Category? Read(Expression<Func<Category, bool>> filter)
    {
        return _context
        .Categories
        .SingleOrDefault(filter);
    }

    public List<Category> ReadAll(Expression<Func<Category, bool>> filter = null)
    {
        // if(filter is null)
        // {
        //     return _context.Categories.ToList();
        // }
        // return _context.Categories.Where(filter).ToList();

        return filter is null
            ? _context.Categories.ToList()
            : _context.Categories.Where(filter).ToList();
    }

    public void Update(Category item)
    {
        _context.Categories.Update(item);
        _context.SaveChanges();
    }
}