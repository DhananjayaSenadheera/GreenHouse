using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDataService.Application.Requests.Sonsors.Commands.Create;
using SensorDataService.Application.Requests.Sonsors.Commands.Delete;
using SensorDataService.Application.Requests.Sonsors.Commands.Update;
using SensorDataService.Application.Requests.Sonsors.Quaries.GetAll;
using SensorDataService.Application.Requests.Sonsors.Quaries.GetOne;

namespace SensorDataService.API.Controllers;

[ApiController]
[Route("api/sensor")]
public class SensorController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SensorCreateCommand command)
    {
        var result = await  mediator.Send(command);
        return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, new {message = "Sensor created successfully"}) : StatusCode(StatusCodes.Status500InternalServerError, new {message = result.Error});
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] SensorUpdateCommand command)
    {
        var result =  await mediator.Send(command);
        if (!result.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {message = result.Error});
        }
        return StatusCode(StatusCodes.Status200OK, new {message = "Sensor updated successfully"});
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] SensorDeleteCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {message = result.Error});
        }
        return StatusCode(StatusCodes.Status200OK, new {message = "Sensor deleted successfully"});
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await mediator.Send(new SensorGetOneCommand(Id));
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Sensor Not Found" });
        }
        return Ok(result.Data);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new SensorGetAllCommand());
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Cant load all sensors" });
        }
        return Ok(result.Data);
    }
}