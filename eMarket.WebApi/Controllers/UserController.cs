using eMarket.Application.DTOs.User;
using eMarket.Application.Feature.User.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto user)
    {
        var command = new RegisterUserCommand
        {
            Username = user.Username,
            Email = user.Email,
            Password = user.Password,
        };
        
        var response = await _mediator.Send<RegisterUserCommand, string>(command);
        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto user)
    {
        var command = new LoginUserCommand
        {
            Email = user.Email,
            Password = user.Password,
        };
        
        var response = await _mediator.Send<LoginUserCommand, string>(command);
        return Ok(response);
    }
}