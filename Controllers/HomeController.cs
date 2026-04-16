using CackoProjekt.Models;
using Microsoft.AspNetCore.Mvc;

namespace CackoProjekt.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomePageViewModel
        {
            Features =
            [
                new FeatureItem("✔️", "Kvalitetni materijali", "Premium papiri i postojane boje za profesionalan završni dojam."),
                new FeatureItem("🚚", "Brza dostava", "Optimiziran proces pripreme i dostave bez kašnjenja."),
                new FeatureItem("🎨", "Personalizacija", "Dizajn prilagođen vašem događaju, stilu i željama."),
                new FeatureItem("🏆", "Iskustvo", "Dugogodišnji rad i stotine uspješno završenih projekata.")
            ],
            Services =
            [
                new ServiceItem("wedding", "Pozivnice za vjenčanje", "Elegantne i personalizirane pozivnice za vaš poseban dan.", "https://images.unsplash.com/photo-1464349153735-7db50ed83c84?auto=format&fit=crop&w=800&q=80", "Pozivnice za vjenčanje"),
                new ServiceItem("business", "Poslovne vizitke", "Moderan i čist dizajn za profesionalnu prezentaciju brenda.", "https://images.unsplash.com/photo-1441986300917-64674bd600d8?auto=format&fit=crop&w=800&q=80", "Poslovne vizitke"),
                new ServiceItem("gift", "Poklon kartice", "Kreativne kartice i bonovi za posebne prilike.", "https://images.unsplash.com/photo-1512909006721-3d6018887383?auto=format&fit=crop&w=800&q=80", "Poklon kartice")
            ],
            Testimonials =
            [
                new TestimonialItem("Ana Kovač", "Od ideje do gotovog proizvoda sve je bilo brzo i profesionalno.", "https://randomuser.me/api/portraits/women/32.jpg"),
                new TestimonialItem("Marko Horvat", "Vizitke su podigle naš brend na novu razinu. Preporuka!", "https://randomuser.me/api/portraits/men/45.jpg"),
                new TestimonialItem("Iva Marić", "Savršena kvaliteta i odlična komunikacija tijekom cijelog procesa.", "https://randomuser.me/api/portraits/women/68.jpg")
            ],
            GalleryItems =
            [
                new GalleryItem("https://images.unsplash.com/photo-1504674900247-0877df9cc836?auto=format&fit=crop&w=600&q=80", "Primjer tiska 1"),
                new GalleryItem("https://images.unsplash.com/photo-1511578314322-379afb476865?auto=format&fit=crop&w=600&q=80", "Primjer tiska 2"),
                new GalleryItem("https://images.unsplash.com/photo-1455885666463-9f41a4e7b54a?auto=format&fit=crop&w=600&q=80", "Primjer tiska 3"),
                new GalleryItem("https://images.unsplash.com/photo-1464349095431-e9a21285b5f3?auto=format&fit=crop&w=600&q=80", "Primjer tiska 4")
            ]
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
