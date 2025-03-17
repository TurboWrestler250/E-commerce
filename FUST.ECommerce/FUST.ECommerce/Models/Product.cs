using System.ComponentModel.DataAnnotations;

namespace FUST.ECommerce.Models;

public class Product
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il titolo è obbligatorio")]
    [StringLength(50, ErrorMessage = "Il titolo può essere lungo massimo 50 caratteri")]
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int? CategoryId { get; set; }
}
