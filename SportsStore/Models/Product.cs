using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models;

// Model class representing a product in the application.
public class Product
{
    public long? ProductId { get; set; }

    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(1024)")]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(8, 2)")] 
    public decimal Price { get; set; }
    
    [Column(TypeName = "nvarchar(128)")]
    public string Category { get; set; } = string.Empty;
}