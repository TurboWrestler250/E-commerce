using FUST.ECommerce.Models;

namespace FUST.ECommerce.Services
{
    public interface IProductsDataAccess
    {
        IEnumerable<Product> GetProducts();
        Product? GetProduct(int id);
        int AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}