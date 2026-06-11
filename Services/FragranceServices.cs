using FragranceVault.Data;
using Microsoft.EntityFrameworkCore;
using FragranceVault.Models;
public class FragranceService
{
    private readonly AppDbContext _context;

    public FragranceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Fragrance>> GetAllAsync()
    {
        return await _context.Fragrances.ToListAsync();
    }
}