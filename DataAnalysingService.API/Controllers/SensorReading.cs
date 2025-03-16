using DataAnalysingService.Application.Requests.SensorReadings.Quaries.GetAll;
using DataAnalysingService.Application.Requests.Sensors.Quaries.GetAll;
using Microsoft.AspNetCore.Mvc;
using MediatR;
namespace DataAnalysingService.API.Controllers;

[ApiController]
[Route("DataAnalysingService/SensorReadings")]
public class SensorReading(IMediator mediator) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new SensorReadingsGetAllQuery());
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Cant load sensors readings." });
        }
        return Ok(result.Data);
    }
}