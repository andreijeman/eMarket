using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.User.Requests;

public class LoginUserCommand : IRequest<string>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}