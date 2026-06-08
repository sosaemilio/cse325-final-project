using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

        // Seed sample fragrances
        builder.Entity<Fragrance>().HasData(
            new Fragrance { Id = 1, Name = "Baccarat Rouge 540", Brand = "Maison Francis Kurkdjian" },
            new Fragrance { Id = 2, Name = "Oud Wood", Brand = "Tom Ford" }
        );
    }
}