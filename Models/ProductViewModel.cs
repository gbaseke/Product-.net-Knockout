using System.ComponentModel.DataAnnotations;

namespace Test.Models;

public class ProductViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public decimal Price { get; set; }
}