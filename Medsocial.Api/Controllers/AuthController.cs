using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using Shared.Enums;
using Shared.Models;

namespace Medsocial.Solution.Controllers;

public class AuthController : ControllerBase
{
    private readonly User _user = new();

    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("register")]
    public ActionResult<User> Register(UserDto request)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        _user.Email = request.Email;
        _user.Password = passwordHash;

        return Ok(_user);
    }

    [HttpPost("login")]
    public ActionResult<User> Login(UserDto userDto)
    {
        _user.Email = userDto.Email;
        _user.Password = userDto.Password;
        
        var token = _serviceManager.TokenService.CreateToken(_user, UserStatus.Costumer);

        return Ok(token);
    }
}