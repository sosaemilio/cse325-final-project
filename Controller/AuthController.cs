using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using FragranceVault.DTOs;
using FragranceVault.Models;

[Route("api/auth")]

public class AuthController: Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


//Register a new user 
    [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
            {
                var user = new ApplicationUser
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };
                Console.WriteLine($"Password received: {dto.Password}");
                var result = await _userManager.CreateAsync(user, dto.Password);

                if (!result.Succeeded)
                {
                    
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(errors);

                }

                return Ok(new {message = "User registered successfully"});
            }
            
    [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return Unauthorized("Invalid credentials");

            var result = await _signInManager.PasswordSignInAsync(
                user,
                dto.Password,
                isPersistent: true,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
                return Redirect("/login?error=invalid");

            return Redirect("/dashboard");
        }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok(new { message = "Logout successful" });
    }
    


}

