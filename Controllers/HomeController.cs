using CackoProjekt.Data;
using CackoProjekt.Models;
using CackoProjekt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CackoProjekt.Controllers;

public class HomeController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var saleProducts = await dbContext.Products
            .Where(p => p.IsOnSale)
            .OrderBy(p => p.Price)
            .Take(4)
            .ToListAsync();

        var bestSellers = await dbContext.Products
            .Where(p => p.IsBestSeller)
            .OrderByDescending(p => p.StockQuantity)
            .Take(4)
            .ToListAsync();

        var viewModel = new HomePageViewModel
        {
            SaleProducts = saleProducts,
            BestSellerProducts = bestSellers
        };

        return View(viewModel);
    }

    public IActionResult Privacy() => View();

    public IActionResult Terms() => View();

    [Route("404")]
    public IActionResult NotFoundPage() => View("NotFound");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
}
