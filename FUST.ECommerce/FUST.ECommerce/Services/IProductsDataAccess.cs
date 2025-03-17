namespace FUST.ECommerce.Services;

using FUST.ECommerce.Models;

public interface IProductsDataAccess
{
    IEnumerable<Product> GetProducts();
    Product? GetProduct(int id);
    int AddProduct(Product product);
    bool UpdateProduct(Product product);
    bool DeleteProduct(int id);
}