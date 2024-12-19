using AuthenticationService.Application.DTOs;
using AuthenticationService.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly RegisterUser _registerUser;
    
    public AuthController(RegisterUser registerUser)
    {
        _registerUser = registerUser;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        await _registerUser.Execute(dto.Email, dto.Password, dto.Role);
        return Ok("User registered successfully");
    }
}