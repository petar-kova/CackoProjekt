namespace CackoProjekt.Models;

public class HomePageViewModel
{
    public string BrandName { get; init; } = "Cacko Print Studio";
    public string HeroTitle { get; init; } = "Personalizirane karte i tiskovine za posebne trenutke";
    public string HeroSubtitle { get; init; } = "Unikatni dizajn i vrhunska kvaliteta tiska.";

    public IReadOnlyList<FeatureItem> Features { get; init; } = [];
    public IReadOnlyList<ServiceItem> Services { get; init; } = [];
    public IReadOnlyList<TestimonialItem> Testimonials { get; init; } = [];
    public IReadOnlyList<GalleryItem> GalleryItems { get; init; } = [];
}

public record FeatureItem(string Icon, string Title, string Description);
public record ServiceItem(string Category, string Name, string Description, string ImageUrl, string ImageAlt);
public record TestimonialItem(string CustomerName, string Comment, string AvatarUrl, int Stars = 5);
public record GalleryItem(string ImageUrl, string ImageAlt);
