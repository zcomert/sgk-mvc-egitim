using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository
    {
        int Count { get; }
        void Create(Category item);
        void Update(Category item);
        void Delete(int id);
        Category? Read(int id);
        List<Category> ReadAll();
    }
}