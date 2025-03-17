namespace FUST.ECommerce.Models;

public class Category
{
    private static int idUser = 0;
    public int Id { get; set; }
    public string Name { get; set; } = $"User-{++idUser}";
}
