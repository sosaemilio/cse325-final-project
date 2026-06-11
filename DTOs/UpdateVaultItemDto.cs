namespace FragranceVault.DTOs;
public class UpdateVaultItemDto
{
    public int Rating { get; set; }
    public string PersonalNotes { get; set; } = string.Empty;   
    public string Season { get; set; } = string.Empty;
    public string Occasion { get; set; } = string.Empty;
}