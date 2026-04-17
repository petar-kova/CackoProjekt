using System.ComponentModel.DataAnnotations;

namespace CackoProjekt.Models;

public class Product
{
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    public ProductType ProductType { get; set; }

    [Range(0, 5000)]
    public int StockQuantity { get; set; }

    public bool IsOnSale { get; set; }

    public bool IsBestSeller { get; set; }

    [Required]
    public string ImageUrl { get; set; } = string.Empty;
}

public enum ProductType
{
    AkrilnaBoja,
    SetKistova,
    Platno,
    Medium,
    Pribor
}
