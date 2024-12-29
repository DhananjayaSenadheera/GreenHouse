using AuthenticationService.Domain.Interfaces;

namespace AuthenticationService.Application.UseCases.DeleteUser;

public class DeleteUserUseCase
{
    private readonly IUserRepository _userRepository;
    public DeleteUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<DeleteUserResponse> AsyncExecute(DeleteUserRequest request)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return new DeleteUserResponse
            {
                Success = false,
                Message = "User not found"
            };
        }

        await _userRepository.DeleteUserAsync(user);
        return new DeleteUserResponse
        {
            Success = true,
            Message = "User deleted"
        };
    }
}