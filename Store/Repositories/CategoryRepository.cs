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

    public void Delete(int id)
    {
        var category = Read(id);
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public Category? Read(int id)
    {
        return _context
        .Categories
        .SingleOrDefault(c => c.CategoryId.Equals(id));
    }

    public List<Category> ReadAll()
    {
        return _context.Categories.ToList();
    }

    public void Update(Category item)
    {
        _context.Categories.Update(item);
        _context.SaveChanges();
    }
}