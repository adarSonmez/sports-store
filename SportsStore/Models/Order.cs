using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models;

// Model class representing an order in the application.
public class Order
{
    [BindNever] // Prevents the user from supplying a value for this property.
    public long OrderId { get; set; }

    [BindNever] public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Please enter a name")]
    [Column(TypeName = "nvarchar(128)")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please enter the first address line")]
    [Column(TypeName = "nvarchar(512)")]
    public string? Line1 { get; set; }

    [Column(TypeName = "nvarchar(512)")] public string? Line2 { get; set; }

    [Column(TypeName = "nvarchar(512)")] public string? Line3 { get; set; }

    [Required(ErrorMessage = "Please enter a city name")]
    [Column(TypeName = "nvarchar(128)")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Please enter a state name")]
    [Column(TypeName = "nvarchar(128)")]
    public string? State { get; set; }

    [Column(TypeName = "nvarchar(128)")] public string? Zip { get; set; }

    [Required(ErrorMessage = "Please enter a country name")]
    [Column(TypeName = "nvarchar(128)")]
    public string? Country { get; set; }

    public bool GiftWrap { get; set; }

    [BindNever] public bool Shipped { get; set; }
}