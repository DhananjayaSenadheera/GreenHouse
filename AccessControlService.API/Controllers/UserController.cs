using AccessControlService.Application.Requests.User.Commands.Create;
using AccessControlService.Application.Requests.User.Commands.Delete;
using AccessControlService.Application.Requests.User.Commands.Update;
using AccessControlService.Application.Requests.User.Quaries.Get;
using AccessControlService.Application.Requests.User.Quaries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccessControlService.API.Controllers;


[ApiController]
[Route("api/accesscontrol")]
public class UserController(IMediator mediator) : ControllerBase
{
    
    [HttpPost("CreateUser")]
    public async Task<IActionResult> Post(CreateUserCommand createUserCommand)
    {
        var result = await mediator.Send(createUserCommand);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var result = await mediator.Send(new GetUserQuary(id));
        if (result is null)
        {
            return NotFound(new { Message = $"User with ID {id} not found." });
        }
        return Ok(result);
    }
    
    [HttpGet("GetUsers")]
    public async Task<IActionResult> GetUsers()
    {
        var result = await mediator.Send(new GetUserListQuary());
        if (result is null)
        {
            return NotFound(new { Message = $"Users not found." });
        }
        return Ok(result);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> Update([FromBody] UpdateUserComand updateUserCommand)
    {
        var result = await mediator.Send(updateUserCommand);
        if (!result)
            return NotFound(new { Message = $"User with ID {updateUserCommand.Id} not found." });
        return Ok(new {message = "User details successfully updated."});
    }

    [HttpDelete("DeleteUser/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
         var result = await mediator.Send( new DeleteUserComand(id));
         if (!result)
         {
             return NotFound(new { Message = $"User with ID {id} was not found." });
         }
         return Ok(new { Message = "User successfully deleted." });
    }
}