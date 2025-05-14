using eMarket.Application.Contracts.Infrastructure;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.User.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Identity;

namespace eMarket.Application.Feature.User.Handlers;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IJwtTokenService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }
    
    public async Task<string> Handle(RegisterUserCommand request)
    {
        if(await _userRepository.AnyEmailAsync(request.Email)) 
            throw new ApplicationException("This email is already registered");

        var user = new Domain.Entities.User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = null!,
            Role = "User"
        };
        
        user.PasswordHash = new PasswordHasher<Domain.Entities.User>()
             .HashPassword(user, request.Password);
        
        user = await _userRepository.AddAsync(user);
        
        return _jwtService.GenerateToken(user);
    }
}