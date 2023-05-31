using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

using Shared.Dtos;

namespace Medsocial.Solution.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public AuthController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody]UserDto userDto)
    {
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(userDto.Password);
        userDto.Password = passwordHash;
        
        var userGuid = await _serviceManager.UserService.AddUserAsync(userDto);
        
        return Ok(userGuid);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login(string email, string password)
    {
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(password);
        var user = await _serviceManager.UserService.GetUserAsync(email, passwordHash, false);
        
        var token = _serviceManager.TokenService.CreateToken(email, user.Status);
    
        return Ok(token);
    }
}