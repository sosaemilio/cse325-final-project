public class VaultItem
{
    public int Id { get; set; }

    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public int FragranceId { get; set; }
    public Fragrance? Fragrance { get; set; }

    public DateTime BuyDate { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public string? PersonalNotes { get; set; }
    public int Rating { get; set; }
}