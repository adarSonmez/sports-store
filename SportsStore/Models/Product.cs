using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models;

// Model class representing a product in the application.
public class Product
{
    public long? ProductId { get; set; }

    [Column(TypeName = "nvarchar(128)")]
    [Required(ErrorMessage = "Please enter a product name")]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(1024)")]
    [Required(ErrorMessage = "Please enter a description")]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(8, 2)")]
    [Range(0.01, double.MaxValue,
        ErrorMessage = "Please enter a positive price")]
    public decimal Price { get; set; }

    [Column(TypeName = "nvarchar(128)")] 
    [Required(ErrorMessage = "Please specify a category")]
    public string Category { get; set; } = string.Empty;
}