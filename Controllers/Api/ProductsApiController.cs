using CackoProjekt.Data;
using CackoProjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CackoProjekt.Controllers.Api;

[ApiController]
[Route("api/products")]
public class ProductsApiController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll(ProductType? type = null, string sortBy = "priceAsc")
    {
        var query = dbContext.Products.AsNoTracking().AsQueryable();

        if (type.HasValue)
        {
            query = query.Where(p => p.ProductType == type.Value);
        }

        query = sortBy switch
        {
            "priceDesc" => query.OrderByDescending(p => p.Price),
            "name" => query.OrderBy(p => p.Name),
            _ => query.OrderBy(p => p.Price)
        };

        return Ok(await query.ToListAsync());
    }
}
