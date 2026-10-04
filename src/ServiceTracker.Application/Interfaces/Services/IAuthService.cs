using ServiceTracker.Application.DTOs.Auth;

namespace ServiceTracker.Application.Interfaces.Services;

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(
        RegisterRequest request,
        CancellationToken cancellationToken
    );
}