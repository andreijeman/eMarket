using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.User.Requests;

public class RegisterUserCommand : IRequest<string>
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}