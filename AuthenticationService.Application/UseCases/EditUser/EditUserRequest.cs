namespace AuthenticationService.Application.UseCases.EditUser;

public class EditUserRequest
{
    public Guid UserId { get; set; }
    public string? NewEmail { get; set; }
    public string? NewPassword { get; set; }
    public string? NewFname { get; set; }
    public string? NewLname { get; set; }
    
}