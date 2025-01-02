using EmailService.Application.Interfaces;
using EmailService.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.API.Controllers;
[ApiController]
[Route("api/email")]
public class EmailController : ControllerBase
{

    private readonly SendEmailUseCase _sendEmailUseCase;
    public EmailController(SendEmailUseCase sendEmailUseCase)
    {
        _sendEmailUseCase = sendEmailUseCase;
    }
   

    [HttpPost]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
    {
         var response = await _sendEmailUseCase.ExecuteAsync(request);
         if (response.IsSuccess == false)
         {
             return BadRequest(new { message = response.Message });
         }
         return Ok(new { message = response.Message });
  
    }
}