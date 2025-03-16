using DataAnalysingService.Application.Requests.GreenHouses.Quaries.Get.ByCode;
using DataAnalysingService.Application.Requests.GreenHouses.Quaries.Get.ById;
using DataAnalysingService.Application.Requests.GreenHouses.Quaries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataAnalysingService.API.Controllers;
[ApiController]
[Route("DataAnalysingService/GreenHouse")]
public class GreenHouseController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetGreenHouseById/{Id}")]
    public async Task<IActionResult> Get(Guid Id)
    {
        var result = await mediator.Send(new GreenHouseGetOneQuery(Id));
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Green House Not Found" });
        }
        return Ok(result.Data);
    }

    [HttpGet("GetGreenHouseByCode/{code}" )]
    public async Task<IActionResult> GetOneByCode(string code)
    {
        var result = await mediator.Send(new GreenHouseGetOneByCodeQuery(code));
        if (!result.IsSuccess)
        {
            return NotFound(new { message = "Green House Not Found" });
        }
        return Ok(result.Data);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var reult = await mediator.Send(new GreenHouseGetAllQuery());
        if (!reult.IsSuccess)
            return NotFound(new { message = "Green House List Not Found" });
        return Ok(reult.Data);
    }
}