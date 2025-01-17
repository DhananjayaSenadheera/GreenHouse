using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDataService.Application.Requests.GreenHouses.Commands.Create;
using SensorDataService.Application.Requests.GreenHouses.Commands.Update;

namespace SensorDataService.API.Controllers;

[ApiController]
[Route("api/greenhouse")]
public class GreenHouseController(IMediator mediator) :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]GreenHouseCreateCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.Error });
        }
        return Ok(new { message = "Green House Created Successfully" });
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] GreenHouseUpdateCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.Error });
        }
        return Ok(new { message = "Green House Updated Successfully" });
    }
  
}