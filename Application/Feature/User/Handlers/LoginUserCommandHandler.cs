using eMarket.Application.Contracts.Infrastructure;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.User.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Identity;

namespace eMarket.Application.Feature.User.Handlers;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtService;
    
    public LoginUserCommandHandler(IUserRepository userRepository, IJwtTokenService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }


    public async Task<string> Handle(LoginUserCommand request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        
        if(user is null) throw new ApplicationException("Wrong password or email");
        
        var result = new PasswordHasher<Domain.Entities.User>()
            .VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new ApplicationException("Wrong password or email");

        return _jwtService.GenerateToken(user);
    }
}