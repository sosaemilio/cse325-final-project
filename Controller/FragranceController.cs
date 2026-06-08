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

    [HttpGet]
    public async Task<IActionResult> GetAll(string? search)
    {
        var query = _context.Fragrances.AsQueryable();

        
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(f =>
                (f.Name ?? "").Contains(search) ||
                (f.Brand ?? "").Contains(search)
            );
        }


        return Ok(await query.ToListAsync());
    }
}