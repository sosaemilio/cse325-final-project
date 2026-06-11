using FragranceVault.Data;
using Microsoft.EntityFrameworkCore;

using FragranceVault.Models;
public class VaultService
{
    private readonly AppDbContext _context;

    public VaultService(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddToVault(string userId, int fragranceId, DateTime buyDate)
    {
        var item = new VaultItem
        {
            UserId = userId,
            FragranceId = fragranceId,
            BuyDate = buyDate
        };

        _context.VaultItems.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<List<VaultItem>> GetUserVault(string userId)
    {
        return await _context.VaultItems
            .Include(v => v.Fragrance)
            .Where(v => v.UserId == userId)
            .ToListAsync();
    }

    public async Task RemoveItem(int id)
    {
        var item = await _context.VaultItems.FindAsync(id);
        if (item != null)
        {
            _context.VaultItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}