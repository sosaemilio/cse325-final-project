using FragranceVault.Data;
public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        if (context.Fragrances.Any()) return;

        context.Fragrances.AddRange(
            new Fragrance { Name = "Sauvage", Brand = "Dior" },
            new Fragrance { Name = "Baccarat Rouge 540", Brand = "Maison Francis Kurkdjian" },
            new Fragrance { Name = "Bleu de Chanel", Brand = "Chanel" }
        );

        context.SaveChanges();
    }
}