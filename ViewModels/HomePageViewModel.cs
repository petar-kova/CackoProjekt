using CackoProjekt.Models;

namespace CackoProjekt.ViewModels;

public class HomePageViewModel
{
    public required IReadOnlyList<Product> SaleProducts { get; init; }
    public required IReadOnlyList<Product> BestSellerProducts { get; init; }
}
