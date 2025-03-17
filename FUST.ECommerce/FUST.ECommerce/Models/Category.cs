using System.ComponentModel.DataAnnotations;

namespace FUST.ECommerce.Models;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Il nome è obbligatorio")]
    [StringLength(50, ErrorMessage = "Il nome può essere lungo massimo 50 caratteri")]
    public string? Name { get; set; }
}
