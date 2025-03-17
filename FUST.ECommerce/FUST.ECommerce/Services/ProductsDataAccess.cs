namespace FUST.ECommerce.Services;

using FUST.ECommerce.Models;
using MySqlConnector;
using Dapper;

public class ProductsDataAccess : IProductsDataAccess
{
    private readonly string _connectionString;

    public ProductsDataAccess(IConfiguration configuration)
    {
        string namedb = "DefaultConnection";
        _connectionString = configuration.GetConnectionString(namedb)
            ?? throw new Exception($"ConnectionString '{namedb}' not found.");
    }

    public IEnumerable<Product> GetProducts()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT productNumber as id, productName, country, creditLimit
                FROM products
                """;
            return connection.Query<Product>(query);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(GetProducts)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(GetProducts)}");
        }
    }

    public Product? GetProduct(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT Id, Title, Description, CategoryId, UserId, Completed, CreateDate, CompletedDate
                FROM products
                WHERE Id = @Id;
                """;
            return connection.QueryFirstOrDefault<Product>(query, new { id });
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(GetProduct)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(GetProduct)}");
        }
    }

    public int AddProduct(Product product)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                INSERT INTO products (Title, Description, CategoryId, UserId, Completed, CompletedDate)
                VALUES (@Title, @Description, @CategoryId, @UserId, @Completed, @CompletedDate);
                SELECT LAST_INSERT_ID() as last_id;
                """;
            return connection.ExecuteScalar<int>(query, product);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(AddProduct)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(AddProduct)}");
        }
    }

    public bool UpdateProduct(Product product)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                UPDATE products
                SET Title = @Title, Description = @Description, CategoryId = @CategoryId, UserId = @UserId, Completed = @Completed, CompletedDate = @CompletedDate
                WHERE Id = @Id;
                """;
            return connection.Execute(query, product) > 0;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(UpdateProduct)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(UpdateProduct)}");
        }
    }

    public bool DeleteProduct(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                DELETE FROM products
                WHERE Id = @Id;
                """;
            return connection.Execute(query, new { id }) > 0;
            //return connection.Execute(query, new { Id = id }) > 0 ? true : false;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(DeleteProduct)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(DeleteProduct)}");
        }
    }
}
