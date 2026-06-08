namespace FragranceVault.DTOs;
public class CreateVaultItemDto
{
    public int FragranceId {get; set; }
    public DateTime BuyDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
}