using FragranceVault.Data;
using FragranceVault.Models;

public static class DbInitializer
{
    public static void Seed(AppDbContext context)
    {
        context.Database.EnsureCreated();
        if (!context.Fragrances.Any())
        {
            context.Fragrances.AddRange(
                new Fragrance { Name = "Sauvage", Brand = "Dior", Notes = "Fresh, spicy", Season = "All", Occasion = "Daily",ImageUrl = "/images/fragrances/Sauvage.webp"},
                new Fragrance { Name = "Bleu de Chanel", Brand = "Chanel", Notes = "Woody, aromatic", Season = "Fall", Occasion = "Evening", ImageUrl = "/images/fragrances/BleuDeChanel.webp" },
                new Fragrance { Name = "Acqua di Gio", Brand = "Armani", Notes = "Marine, fresh", Season = "Summer", Occasion = "Casual", ImageUrl = "/images/fragrances/AcquaDiGio.webp" },
                new Fragrance { Name = "Versace Eros", Brand = "Versace", Notes = "Sweet, minty", Season = "Winter", Occasion = "Night", ImageUrl = "/images/fragrances/VersaceEros.webp" },
                new Fragrance { Name = "Y EDP", Brand = "YSL", Notes = "Fresh, apple", Season = "Spring", Occasion = "Office", ImageUrl = "/images/fragrances/YEDP.webp" },
                new Fragrance { Name = "Baccarat Rouge 540", Brand = "MFK", Notes = "Sweet, amber", Season = "Winter", Occasion = "Formal", ImageUrl = "/images/fragrances/BaccaratRouge540.webp" },
                new Fragrance { Name = "Aventus", Brand = "Creed", Notes = "Fruity, smoky", Season = "All", Occasion = "Formal", ImageUrl =  "/images/fragrances/Aventus.webp" },
                new Fragrance { Name = "Spicebomb", Brand = "Viktor & Rolf", Notes = "Spicy, warm", Season = "Winter", Occasion = "Night", ImageUrl =  "/images/fragrances/Spicebomb.webp" },
                new Fragrance { Name = "The One", Brand = "Dolce & Gabbana", Notes = "Warm, tobacco", Season = "Fall", Occasion = "Date", ImageUrl =  "/images/fragrances/TheOne.webp" },
                new Fragrance { Name = "Light Blue", Brand = "Dolce & Gabbana", Notes = "Citrus, fresh", Season = "Summer", Occasion = "Casual", ImageUrl =  "/images/fragrances/LightBlue.webp" },
                new Fragrance { Name = "Dylan Blue", Brand = "Versace", Notes = "Fresh, aquatic", Season = "Summer", Occasion = "Daily", ImageUrl =  "/images/fragrances/DylanBlue.webp" },
                new Fragrance { Name = "Explorer", Brand = "Montblanc", Notes = "Bergamot, woody", Season = "All", Occasion = "Office", ImageUrl =  "/images/fragrances/Explorer.webp" },
                new Fragrance { Name = "Invictus", Brand = "Paco Rabanne", Notes = "Fresh, sporty", Season = "Summer", Occasion = "Casual", ImageUrl =  "/images/fragrances/Invictus.webp" },
                new Fragrance { Name = "Hawas", Brand = "Rasasi", Notes = "Citrus, aquatic", Season = "Summer", Occasion = "Casual", ImageUrl =  "/images/fragrances/Hawas.webp" },
                new Fragrance { Name = "Oud Wood", Brand = "Tom Ford", Notes = "Woody, oud", Season = "Winter", Occasion = "Formal", ImageUrl =  "/images/fragrances/OudWood.webp" },
                new Fragrance { Name = "Noir Extreme", Brand = "Tom Ford", Notes = "Sweet, spicy", Season = "Fall", Occasion = "Date", ImageUrl =  "/images/fragrances/NoirExtreme.webp" },
                new Fragrance { Name = "Tuscan Leather", Brand = "Tom Ford", Notes = "Leather, smoky", Season = "Winter", Occasion = "Night", ImageUrl =  "/images/fragrances/TuscanLeather.webp" },
                new Fragrance { Name = "Jazz Club", Brand = "Maison Margiela", Notes = "Rum, tobacco", Season = "Winter", Occasion = "Night", ImageUrl =  "/images/fragrances/JazzClub.webp" },
                new Fragrance { Name = "By the Fireplace", Brand = "Maison Margiela", Notes = "Smoky, sweet", Season = "Winter", Occasion = "Cozy", ImageUrl =  "/images/fragrances/ByTheFireplace.webp" },
                new Fragrance { Name = "Layton", Brand = "Parfums de Marly", Notes = "Apple, vanilla", Season = "Fall", Occasion = "Date", ImageUrl =
                    "/images/fragrances/Layton.webp" },
                new Fragrance { Name = "Elysium", Brand = "Roja", Notes = "Citrus, luxurious", Season = "Summer", Occasion = "Formal", ImageUrl =  "/images/fragrances/Elysium.webp" },
                new Fragrance { Name = "Virgin Island Water", Brand = "Creed", Notes = "Coconut, lime", Season = "Summer", Occasion = "Beach", ImageUrl =  "/images/fragrances/VirginIslandWater.webp" },
                new Fragrance { Name = "Royal Oud", Brand = "Creed", Notes = "Woody, elegant", Season = "Winter", Occasion ="Formal", ImageUrl=  "/images/fragrances/RoyalOud.webp" },
                new Fragrance { Name = "Ombre Leather", Brand= "Tom Ford", Notes= "Leather, bold", Season= "Fall", Occasion="Night", ImageUrl=  "/images/fragrances/OmbreLeather.webp" },
                new Fragrance { Name= "Fahrenheit", Brand= "Dior", Notes="Gasoline, leather", Season= "Fall", Occasion="Evening", ImageUrl=  "/images/fragrances/Fahrenheit.webp" },
                new Fragrance { Name = "CK One", Brand = "Calvin Klein", Notes = "Citrus, light", Season = "Summer", Occasion = "Casual", ImageUrl =  "/images/fragrances/CKOne.webp" },
                new Fragrance { Name = "Eternity", Brand = "Calvin Klein", Notes = "Fresh, floral", Season = "Spring", Occasion = "Daily", ImageUrl =  "/images/fragrances/Eternity.webp" },
                new Fragrance { Name = "Obsession", Brand = "Calvin Klein", Notes = "Warm, spicy", Season = "Fall", Occasion = "Evening",
                    ImageUrl =  "/images/fragrances/Obsession.webp" },
                new Fragrance { Name = "Date For Men", Brand = "Calvin Klein", Notes = "Citrus, fresh", Season = "Summer", Occasion = "Date", ImageUrl =  "/images/fragrances/DateForMen.webp" },
                new Fragrance { Name = "Herod", Brand = "Parfums de Marly", Notes = "Citrus, spicy", Season = "Spring", Occasion = "Office", ImageUrl =  "/images/fragrances/Herod.webp" }
                
            );

            context.SaveChanges();
        }
    }
}