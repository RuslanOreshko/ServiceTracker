using ServiceTracker.Application.DTOs.Auth;
using ServiceTracker.Application.Exceptions;
using ServiceTracker.Application.Interfaces.Persistence;
using ServiceTracker.Application.Interfaces.Services;
using ServiceTracker.Domain.Entities;

namespace ServiceTracker.Application.Services;


public class AuthService : IAuthService
{
    private readonly IUserRepositories _userRepository;
    private readonly IProfileRepositories _profileRepository;
    private readonly IPrivacySettingsRepository _privacySettingsRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IApplicationDbContext _dbContext;

    public AuthService(
        IUserRepositories userRepositories,
        IProfileRepositories profileRepositories,
        IPrivacySettingsRepository privacySettingsRepository,
        IPasswordHasher passwordHasher,
        IApplicationDbContext dbContext
    )
    {
        _userRepository = userRepositories;
        _profileRepository = profileRepositories;
        _privacySettingsRepository = privacySettingsRepository;

        _passwordHasher = passwordHasher;

        _dbContext = dbContext;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
    {
        var existsEmail = await _userRepository.ExistsByEmailAsync(request.Email, cancellationToken);

        var usernameExists = await _profileRepository.ExistsByUsernameAsync(request.Username, cancellationToken);

        if(existsEmail)
            throw new EmailAlredyExistsException();
        
        if(usernameExists)
            throw new UsernameAlredyExistsException();

        
        // Password hashing
        var passwordHash = _passwordHasher.Hash(request.Password);


        var user = new User(
            request.Email,
            passwordHash
        );

        await _userRepository.AddAsync(user, cancellationToken);


        var profile = new Profile(
            user.Id,
            request.Username,
            request.DisplayName
        );

        await _profileRepository.AddAsync(profile, cancellationToken);


        var privacySettings = new PrivacySettings(user.Id);

        await _privacySettingsRepository.AddAsync(privacySettings, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new RegisterResponse
        {
            UserId = user.Id,
            Email = user.Email,
            Username = profile.Username
        };
    }
}