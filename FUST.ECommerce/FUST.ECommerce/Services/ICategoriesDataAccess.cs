using FUST.ECommerce.Models;

namespace FUST.ECommerce.Services
{
    public interface ICategoriesDataAccess
    {
        IEnumerable<Category> GetCategories();
        Category? GetCategory(int id);
        int AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}