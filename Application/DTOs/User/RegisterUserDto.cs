namespace eMarket.Application.DTOs.User;

public class RegisterUserDto
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}