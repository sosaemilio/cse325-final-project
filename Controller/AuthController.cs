using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using FragranceVault.DTOs;
using FragranceVault.Models;
using System.Diagnostics.CodeAnalysis;

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


   // Handles user registration
[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterDto dto)
{
    // Create a new user using the data from the request
    var user = new ApplicationUser
    {
        UserName = dto.Email,   // Email is used as the username
        Email = dto.Email,
        FirstName = dto.FirstName,
        LastName = dto.LastName
    };

    // Log password for debugging purposes (should be removed in production)
    Console.WriteLine($"Password received: {dto.Password}");

    // Attempt to create the user in the Identity system
    var result = await _userManager.CreateAsync(user, dto.Password);

    // If registration fails, process the errors
    if (!result.Succeeded)
    {
        var errors = result.Errors.Select(e =>
        {
            // Provide a user-friendly message for duplicate email
            if (e.Code == "DuplicateUserName" || e.Code == "DuplicateEmail")
                return "An account with this email already exists";

            // Return default error message for other cases
            return e.Description;
        });

        // Return error response to the client
        return BadRequest(errors);
    }

    // Return success message if registration succeeds
    return Ok(new { message = "User registered successfully" });
}


    // Handles user login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginDto dto)
    {
        // Look for a user with the provided email
        var user = await _userManager.FindByEmailAsync(dto.Email);

        // If no user is found, redirect back to login with an error
        if (user == null)
            return Redirect("/login?error=invalid");

        // Attempt to sign in using the provided password
        var result = await _signInManager.PasswordSignInAsync(
            user,
            dto.Password,
            isPersistent: true,     // Keeps the user logged in across sessions
            lockoutOnFailure: false
        );

        // If login fails, redirect back with an error
        if (!result.Succeeded)
            return Redirect("/login?error=invalid");

        // Add additional claims (used to display the user's first name in the UI)
        var claims = new List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim("FirstName", user.FirstName)
        };

        // Sign in again with the custom claims included
        await _signInManager.SignInWithClaimsAsync(user, isPersistent: true, claims);

        // Redirect to the dashboard after successful login
        return Redirect("/dashboard");
    }


    // Handles user logout
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Sign the user out and remove authentication session
        await _signInManager.SignOutAsync();

        // Redirect to the homepage after logout
        return Redirect("/");
    }


}

