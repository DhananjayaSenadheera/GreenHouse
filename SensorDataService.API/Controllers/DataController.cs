using Microsoft.AspNetCore.Mvc;

namespace SensorDataService.API.Controllers;

[ApiController]
[Route("api/Data")]
public class DataController : ControllerBase
{
   [HttpPost]
   public async Task<IActionResult> AddSensorData()
   {
      return Ok();
   }
}