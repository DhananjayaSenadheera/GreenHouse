using MediatR;
using Microsoft.AspNetCore.Mvc;
using DataStorageService.Application.Requests.Sensors.Commands.Create;
using DataStorageService.Application.Requests.Sensors.Commands.Delete;
using DataStorageService.Application.Requests.Sensors.Commands.Update;


namespace DataStorageService.API.Controllers;

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
  
}