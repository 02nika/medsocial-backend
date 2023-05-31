using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;

namespace Medsocial.Solution.Controllers;

public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register([FromBody]UserDto userDto)
    {
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(userDto.Password);
        userDto.Password = passwordHash;
        
        var newUser = await _serviceManager.UserService.AddUserAsync(userDto);
        
        return Ok(newUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(string email, string password)
    {
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(password);
        var user = await _serviceManager.UserService.GetUserAsync(email, passwordHash, false);
        
        var token = _serviceManager.TokenService.CreateToken(email, user.Status.Name);

        return Ok(token);
    }
}