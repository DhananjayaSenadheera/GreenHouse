using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases.PasswordManager;

public class ResetPasswordUseCase
{
    private readonly IUserRepository _userRepository;
    public ResetPasswordUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /*public async Task<ResetPasswordResponse> RestAsync(ResetPasswordRequest request)
    {
        var response = await _userRepository.GetUserByIdAsync(request.UserId);
        if (response is null)
        {
            return new ResetPasswordResponse{  Message = "User not found."};
        }

        if (request.NewPassword == null)
        {
            return new ResetPasswordResponse{  Message = "New password is required."};
        }
        
    }*/
}