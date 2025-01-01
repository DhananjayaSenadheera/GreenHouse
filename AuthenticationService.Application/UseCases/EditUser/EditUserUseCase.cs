using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases.EditUser;

public class EditUserUseCase
{
    private readonly IUserRepository _userRepository;
    public EditUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<EditUserResponse> ExecuteAsync(EditUserRequest request)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return new EditUserResponse
            {
                Message = "User not found",
                Success = false
            };
        }
        if (!string.IsNullOrEmpty(request.NewPassword))
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        }
        
        if (!string.IsNullOrEmpty(request.NewEmail))
        {
            user.Email = request.NewEmail;
        }
        if (!string.IsNullOrEmpty(request.NewFname))
        {
            user.Email = request.NewFname;
        }
        if (!string.IsNullOrEmpty(request.NewLname))
        {
            user.Email = request.NewLname;
        }
        await _userRepository.UpdateUserAsync(user);
        return new EditUserResponse
        {
            Message = "User updated",
            Success = true
        };
    }
}