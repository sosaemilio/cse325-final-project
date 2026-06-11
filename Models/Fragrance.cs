
namespace FragranceVault.Models;

public class Fragrance
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;

    public string Notes { get; set; } = string.Empty;
    public string Season { get; set; } = string.Empty;
    public string Occasion { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
}