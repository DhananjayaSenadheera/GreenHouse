using MediatR;
using Microsoft.AspNetCore.Mvc;
using SensorDataService.Application.Requests.GreenHouses.Commands.Create;
using SensorDataService.Application.Requests.GreenHouses.Commands.Delete;
using SensorDataService.Application.Requests.GreenHouses.Commands.Update;
using SensorDataService.Application.Requests.GreenHouses.Quaries.Get;
using SensorDataService.Application.Requests.GreenHouses.Quaries.GetAll;

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

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] GreenHouseDeleteCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = result.Error });
        }
        return Ok(new { message = "Green House Deleted Successfully" });
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var result = await mediator.Send(new GreenHouseGetOneCommand(Id));
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Green House Not Found" });
        }
        return Ok(result.Data);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var reult = await mediator.Send(new GreeHouseGetAllCommand());
        if (!reult.IsSuccess)
            return NotFound(new { message = "Green House List Not Found" });
        return Ok(reult.Data);
    }
}