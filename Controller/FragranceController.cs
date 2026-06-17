using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FragranceVault.Data;

[Route("api/fragrances")]
[ApiController]
public class FragranceController : ControllerBase
{
    private readonly AppDbContext _context;

    public FragranceController(AppDbContext context)
    {
        _context = context;
    }

    // Retrieves all fragrances, with optional search filtering
    [HttpGet]
    public async Task<IActionResult> GetAll(string? search)
    {
        // Start with the full list of fragrances as a queryable object
        var query = _context.Fragrances.AsQueryable();

        // If a search term is provided, filter results by name or brand
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(f =>
                (f.Name ?? "").Contains(search) ||     // Match fragrance name
                (f.Brand ?? "").Contains(search)       // Match fragrance brand
            );
        }

        // Execute the query and return the results as a list
        return Ok(await query.ToListAsync());
    }


    // Retrieves a single fragrance by its ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        // Attempt to find the fragrance using its primary key
        var fragrance = await _context.Fragrances.FindAsync(id);

        // If no fragrance is found, return a 404 response
        if (fragrance == null)
            return NotFound();

        // Return the found fragrance
        return Ok(fragrance);
    }

       
}



    
