using Microsoft.AspNetCore.Mvc;
using ServiceTracker.Application.DTOs.Auth;
using ServiceTracker.Application.Interfaces.Services;

namespace ServiceTracker.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService authService
    )
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegisterResponse>> Register(
        [FromBody] RegisterRequest request,
        CancellationToken cancellationToken
    )
    {
        var response = await _authService.RegisterAsync(request, cancellationToken);

        return Created(
            $"api/profiles/{response.Username}",
            response
        );
    }
}