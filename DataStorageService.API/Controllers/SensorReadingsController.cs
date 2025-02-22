using MediatR;
using Microsoft.AspNetCore.Mvc;
using DataStorageService.Application.Requests.SensorReadings.Commands.Create;

namespace DataStorageService.API.Controllers;

[ApiController]
[Route("api/Data")]
public class SensorReadingsController(IMediator mediator) : ControllerBase
{
   [HttpPost]
   public async Task<IActionResult> AddSensorData([FromBody] SensorReadingCreateCommand command)
   {
      var result = await  mediator.Send(command);
      return result.IsSuccess ? StatusCode(StatusCodes.Status200OK, new {message = "Records Captured Successfully",result.Data}) : StatusCode(StatusCodes.Status500InternalServerError, new {message = result.Error});
     // return Ok("Data Recived"+StatusCodes.Status200OK);
   }
}