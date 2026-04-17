using CackoProjekt.Data;
using CackoProjekt.Models;
using CackoProjekt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CackoProjekt.Controllers;

public class ProductsController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index(string sortBy = "priceAsc", ProductType? productType = null)
    {
        var query = dbContext.Products.AsNoTracking().AsQueryable();

        if (productType.HasValue)
        {
            query = query.Where(p => p.ProductType == productType.Value);
        }

        query = sortBy switch
        {
            "priceDesc" => query.OrderByDescending(p => p.Price),
            "name" => query.OrderBy(p => p.Name),
            _ => query.OrderBy(p => p.Price)
        };

        var products = await query.ToListAsync();
        var viewModel = new ProductListViewModel
        {
            Products = products,
            SortBy = sortBy,
            SelectedType = productType
        };

        return View(viewModel);
    }
}
