using Microsoft.AspNetCore.Identity;

namespace FragranceVault.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<VaultItem>? VaultItems { get; set; }
}