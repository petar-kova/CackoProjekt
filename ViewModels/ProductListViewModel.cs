using CackoProjekt.Models;

namespace CackoProjekt.ViewModels;

public class ProductListViewModel
{
    public required IReadOnlyList<Product> Products { get; init; }
    public string SortBy { get; init; } = "priceAsc";
    public ProductType? SelectedType { get; init; }
    public IReadOnlyList<ProductType> Types { get; init; } = Enum.GetValues<ProductType>();
}
