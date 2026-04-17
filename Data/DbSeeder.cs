using CackoProjekt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CackoProjekt.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        await db.Database.MigrateAsync();

        if (!await userManager.Users.AnyAsync())
        {
            var admin = new IdentityUser { UserName = "admin@akril-shop.hr", Email = "admin@akril-shop.hr", EmailConfirmed = true };
            await userManager.CreateAsync(admin, "Admin123!");
        }

        if (await db.Products.AnyAsync())
        {
            return;
        }

        var products = new List<Product>
        {
            new() { Name = "Akrilna boja set 24", Description = "Profesionalni set bogatih pigmenata.", Price = 29.99m, ProductType = ProductType.AkrilnaBoja, IsOnSale = true, IsBestSeller = true, StockQuantity = 25, ImageUrl = "https://images.unsplash.com/photo-1513360371669-4adf3dd7dff8?auto=format&fit=crop&w=800&q=80" },
            new() { Name = "Akrilna boja Titanium White", Description = "Visoka pokrivnost i brzo sušenje.", Price = 5.49m, ProductType = ProductType.AkrilnaBoja, IsOnSale = true, IsBestSeller = false, StockQuantity = 120, ImageUrl = "https://images.unsplash.com/photo-1452860606245-08befc0ff44b?auto=format&fit=crop&w=800&q=80" },
            new() { Name = "Set kistova Premium", Description = "12 sintetičkih kistova raznih dimenzija.", Price = 18.50m, ProductType = ProductType.SetKistova, IsOnSale = false, IsBestSeller = true, StockQuantity = 44, ImageUrl = "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?auto=format&fit=crop&w=800&q=80" },
            new() { Name = "Platno 40x50 cm", Description = "Pripremljeno pamučno platno za akril.", Price = 9.99m, ProductType = ProductType.Platno, IsOnSale = false, IsBestSeller = true, StockQuantity = 70, ImageUrl = "https://images.unsplash.com/photo-1579783902614-a3fb3927b6a5?auto=format&fit=crop&w=800&q=80" },
            new() { Name = "Akrilni medium gloss", Description = "Medium za pojačani sjaj i transparentnost.", Price = 11.20m, ProductType = ProductType.Medium, IsOnSale = true, IsBestSeller = false, StockQuantity = 31, ImageUrl = "https://images.unsplash.com/photo-1460661419201-fd4cecdf8a8b?auto=format&fit=crop&w=800&q=80" },
            new() { Name = "Paleta za miješanje", Description = "Ergonomska paleta s odjeljcima.", Price = 6.70m, ProductType = ProductType.Pribor, IsOnSale = false, IsBestSeller = false, StockQuantity = 53, ImageUrl = "https://images.unsplash.com/photo-1452860606245-08befc0ff44b?auto=format&fit=crop&w=800&q=80" }
        };

        await db.Products.AddRangeAsync(products);
        await db.SaveChangesAsync();
    }
}
