using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

using FragranceVault.DTOs;
using FragranceVault.Data;
using FragranceVault.Models;

[Route("api/vault")]
[ApiController]
[Authorize]
public class VaultController : ControllerBase
{
    private readonly AppDbContext _context;

    public VaultController(AppDbContext context)
    {
        _context = context;
    }

    
    private string GetUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            throw new UnauthorizedAccessException("User not authenticated.");

        return userId;
    }


    // GET: api/vault
    [HttpGet]
    public async Task<IActionResult> GetVault()
    {
        var userId = GetUserId();

        var vault = await _context.VaultItems
            .Where(v => v.UserId == userId)
            .Include(v => v.Fragrance)
            .ToListAsync();

        return Ok(vault);
    }

    // POST: api/vault
    [HttpPost]
    public async Task<IActionResult> AddToVault(CreateVaultItemDto dto)
    {
        var userId = GetUserId();

        var item = new VaultItem
        {
            UserId = userId,
            FragranceId = dto.FragranceId,
            BuyDate = dto.BuyDate,
            ExpirationDate = dto.ExpirationDate
        };

        _context.VaultItems.Add(item);
        await _context.SaveChangesAsync();

        return Ok(item);
    }

    // PUT: api/vault/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVault(int id, UpdateVaultItemDto dto)
    {
        var userId = GetUserId();

        var item = await _context.VaultItems.FindAsync(id);

        if (item == null || item.UserId != userId)
            return Unauthorized();

        item.Rating = dto.Rating;
        item.PersonalNotes = dto.PersonalNotes;
        item.Season = dto.Season;
        item.Occasion = dto.Occasion;

        await _context.SaveChangesAsync();

        return Ok(item);
    }

    // DELETE: api/vault/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetUserId();

        var item = await _context.VaultItems.FindAsync(id);

        if (item == null || item.UserId != userId)
            return Unauthorized();

        _context.VaultItems.Remove(item);
        await _context.SaveChangesAsync();

        return Ok();
    }
}