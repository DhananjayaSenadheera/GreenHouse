using AuthenticationService.Domain.Entities;

namespace AuthenticationService.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}