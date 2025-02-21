using AuthenticationService.Application.UseCases;
using AuthenticationService.Application.UseCases.DeleteUser;
using AuthenticationService.Application.UseCases.EditUser;
using AuthenticationService.Application.UseCases.GetUser;
using AuthenticationService.Application.UseCases.LoginUser;
using AuthenticationService.Application.UseCases.RegisterUser;
using AuthenticationService.Application.UseCases.Users.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IMediator mediator) : ControllerBase
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly LoginUserUseCase _loginUserUseCase;
    private readonly GetUserUseCase _getUserUseCase;
    private readonly EditUserUseCase _editUserUseCase;
    private readonly DeleteUserUseCase _deleteUserUseCase;
    
    /*public AuthController(RegisterUserUseCase registerUserUseCase, LoginUserUseCase loginUserUseCase, GetUserUseCase getUserUseCase, EditUserUseCase editUserUseCase, DeleteUserUseCase deleteUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _loginUserUseCase = loginUserUseCase;
        _getUserUseCase = getUserUseCase;
        _editUserUseCase = editUserUseCase;
        _deleteUserUseCase = deleteUserUseCase;
    }*/
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
    {
        /*var response = await _registerUserUseCase.ExecuteAsync(registerUserRequest);
        if (response.Message == "User already exists" )
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(response);*/
        var result = await mediator.Send(command);
        return Ok(result);
    }

    /*[HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest  loginUserRequest)
    {
       var response = await _loginUserUseCase.ExecuteAsync(loginUserRequest);
       if (response.Message == "Invalid email or password")
       {
           return Unauthorized(new { message = response.Message });
       }
       return Ok(new { message = response.Message ,token = response.Token });
    }
    
    [HttpGet("Profile")]
    [Authorize]
    public async Task<IActionResult> Getprofile()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new { message = "User does not exist" });
        }

        var request = new GetUserRequest
        {
            UserId = Guid.Parse(userId),
        };
        
        var response = await _getUserUseCase.ExecuteAsync(request);
        if (response == null)
        {
            return NotFound(new { message = "User does not exist" });
        }
        return Ok(response);
    }

    [HttpPut("Edit")]
    [Authorize]
    public async Task<IActionResult> EditProfile([FromBody] EditUserRequest editUserRequest)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new { message = "User ID not found in token" });
        }
        
        editUserRequest.UserId = Guid.Parse(userId);
        var response = await _editUserUseCase.ExecuteAsync(editUserRequest);
        if (!response.Success)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(new { message = response.Message });
    }
    
    [HttpDelete("Delete")]
    [Authorize]
    public async Task<IActionResult> DeleteUser()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(new { message = "User does not exist" });
        }

        var request = new DeleteUserRequest
        {
            UserId = Guid.Parse(userId),
        };
        
        var response = await _deleteUserUseCase.AsyncExecute(request);
        
        if (!response.Success)
        {
            return NotFound(new { message = response.Message });
        }
        return Ok(new { message = response.Message });
    }*/
}