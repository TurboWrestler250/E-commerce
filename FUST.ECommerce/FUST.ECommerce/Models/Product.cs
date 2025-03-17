namespace FUST.ECommerce.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int CategoryId { get; set; }
    public string UserId { get; set; } = "";
    public bool Completed { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime CompletedDate { get; set; }
}
