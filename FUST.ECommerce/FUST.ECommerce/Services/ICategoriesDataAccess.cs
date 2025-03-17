namespace FUST.ECommerce.Services;

using FUST.ECommerce.Models;

public interface ICategoriesDataAccess
{
    IEnumerable<Category> GetCategories();
    Category? GetCategory(int id);
    int AddCategory(Category category);
    bool UpdateCategory(Category category);
    bool DeleteCategory(int id);
}