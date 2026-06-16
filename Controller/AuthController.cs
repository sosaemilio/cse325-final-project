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
                    
                    var errors = result.Errors.Select(e =>
                    {
                        if (e.Code == "DuplicateUserName" || e.Code == "DuplicateEmail")
                            return "An account with this email already exists";

                        return e.Description;
                    });

                    return BadRequest(errors);

                }

                return Ok(new {message = "User registered successfully"});
            }
            
    [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return Redirect("/login?error=invalid");

            var result = await _signInManager.PasswordSignInAsync(
                user,
                dto.Password,
                isPersistent: true,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
                return Redirect("/login?error=invalid");

            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("FirstName", user.FirstName)
            };

            await _signInManager.SignInWithClaimsAsync(user, isPersistent: true, claims);

            return Redirect("/dashboard");
        }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/");
    }
    


}

