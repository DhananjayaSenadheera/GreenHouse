using DataAnalysingService.Application.Requests.Sensors.Quaries.GetAll;
using DataAnalysingService.Application.Requests.Sensors.Quaries.GetOne;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataAnalysingService.API.Controllers;
[ApiController]
[Route("DataAnalysingService/sensor")]
public class SensorController(IMediator mediator) : ControllerBase
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var result = await mediator.Send(new SensorGetOneQuery(Id));
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Sensor Not Found" });
        }
        return Ok(result.Data);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new SensorGetAllQuery());
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Cant load all sensors" });
        }
        return Ok(result.Data);
    }
}