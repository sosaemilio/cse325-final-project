namespace FragranceVault.Models;
public class VaultItem
{
    public int Id { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    public int FragranceId { get; set; }
    public Fragrance? Fragrance { get; set; }

    public DateTime BuyDate { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public string PersonalNotes { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Season { get; set; } = string.Empty;
    public string Occasion { get; set; } = string.Empty;


}