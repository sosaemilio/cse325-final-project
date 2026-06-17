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

    
    // Retrieves the current logged-in user's ID from authentication claims
private string GetUserId()
{
    // Extract the user's unique ID from claims
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

    // If no user ID is found, the user is not authenticated
    if (userId == null)
        throw new UnauthorizedAccessException("User not authenticated.");

    return userId;
}


// GET: api/vault
// Retrieves all vault items belonging to the current user
[HttpGet]
public async Task<IActionResult> GetVault()
{
    // Get the current user's ID
    var userId = GetUserId();

    // Query vault items that belong only to this user
    // Include related fragrance data for display purposes
    var vault = await _context.VaultItems
        .Where(v => v.UserId == userId)
        .Include(v => v.Fragrance)
        .ToListAsync();

    // Return the user's vault items
    return Ok(vault);
}


    // POST: api/vault
    // Adds a new fragrance to the user's vault
    [HttpPost]
    public async Task<IActionResult> AddToVault(CreateVaultItemDto dto)
    {
        // Get the current user's ID
        var userId = GetUserId();

        // Create a new vault item using the provided data
        var item = new VaultItem
        {
            UserId = userId,                // Associate item with current user
            FragranceId = dto.FragranceId,  // Reference selected fragrance
            BuyDate = dto.BuyDate,
            ExpirationDate = dto.ExpirationDate
        };

        // Add the item to the database
        _context.VaultItems.Add(item);
        await _context.SaveChangesAsync();

        // Return the newly created item
        return Ok(item);
    }


    // PUT: api/vault/{id}
    // Updates an existing vault item
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVault(int id, UpdateVaultItemDto dto)
    {
        // Get the current user's ID
        var userId = GetUserId();

        // Find the vault item by ID
        var item = await _context.VaultItems.FindAsync(id);

        // Ensure the item exists and belongs to the current user
        if (item == null || item.UserId != userId)
            return Unauthorized();

        // Update editable fields with new values
        item.Rating = dto.Rating;
        item.PersonalNotes = dto.PersonalNotes;
        item.Season = dto.Season;
        item.Occasion = dto.Occasion;

        // Save changes to the database
        await _context.SaveChangesAsync();

        // Return the updated item
        return Ok(item);
    }


    // DELETE: api/vault/{id}
    // Deletes a vault item belonging to the user
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // Get the current user's ID
        var userId = GetUserId();

        // Find the vault item by ID
        var item = await _context.VaultItems.FindAsync(id);

        // Ensure the item exists and belongs to the current user
        if (item == null || item.UserId != userId)
            return Unauthorized();

        // Remove the item from the database
        _context.VaultItems.Remove(item);
        await _context.SaveChangesAsync();

        // Return success response
        return Ok();
    }
}