namespace FUST.ECommerce.Services;

using FUST.ECommerce.Models;
using MySqlConnector;
using Dapper;

public class CategoriesDataAccess : ICategoriesDataAccess
{
    private readonly string _connectionString;

    public CategoriesDataAccess(IConfiguration configuration)
    {
        string namedb = "DefaultConnection";
        _connectionString = configuration.GetConnectionString(namedb)
            ?? throw new Exception($"ConnectionString '{namedb}' not found.");
    }

    // METODI C-R-U-D
    public IEnumerable<Category> GetCategories()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT id, name
                FROM categories;
                """;
            return connection.Query<Category>(query);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(GetCategories)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(GetCategories)}");
        }
    }
    
    public Category? GetCategory(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT id, name
                FROM categories
                WHERE id = @Id;
                """;
            return connection.QueryFirstOrDefault<Category>(query, new { id });
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(GetCategory)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(GetCategory)}");
        }
    }
    
    public int AddCategory(Category category)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                INSERT INTO categories (Name)
                VALUES (@Name);
                SELECT LAST_INSERT_ID() as last_id;
                """;
            return connection.ExecuteScalar<int>(query, category);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(AddCategory)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(AddCategory)}");
        }
    }
    
    public bool UpdateCategory(Category category)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                UPDATE categories
                SET Name = @Name
                WHERE Id = @Id;
                """;
            return connection.Execute(query, category) > 0;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(UpdateCategory)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(UpdateCategory)}");
        }
    }
    
    public bool DeleteCategory(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                DELETE FROM categories
                WHERE Id = @Id;
                """;
            return connection.Execute(query, new { id }) > 0;
            //return connection.Execute(query, new { Id = id }) > 0 ? true : false;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, $"Error on {nameof(DeleteCategory)} method.");

            Console.WriteLine($"Errore: {ex.Message}");
            Console.WriteLine($"Dettagli: {ex.StackTrace}");
            throw new Exception($"Si è verificato un errore in {nameof(DeleteCategory)}");
        }
    }
}
