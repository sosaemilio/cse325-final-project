using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FragranceVault.Models;

namespace FragranceVault.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Fragrance> Fragrances { get; set; }
    public DbSet<VaultItem> VaultItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
}