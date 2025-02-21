using DataCapturingService.Application.Requests.SensorReadings.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataCapturingService.API.Controllers;

[ApiController]
[Route("api/DataCapturing")]
public class DataCapturingController(IMediator mediator) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> AddSensorData([FromBody] SendDataCommand command)
    {
        await  mediator.Send(command);
        return Ok();
        //return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, new {message = "Records Captured Successfully",result.Data}) : StatusCode(StatusCodes.Status500InternalServerError, new {message = result.Error});
        // return Ok("Data Recived"+StatusCodes.Status200OK);
    }
}