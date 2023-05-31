using Entities.Exceptions;
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
        if (await _serviceManager.UserService.UserExistAsync(userDto.Email)) throw new UserAlreadyExistsException();
        
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(userDto.Password);
        userDto.Password = passwordHash;
        
        var userGuid = await _serviceManager.UserService.AddUserAsync(userDto);
        
        return Ok(userGuid);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login(UserLoginDto userLoginDto)
    {
        var passwordHash = _serviceManager.PasswordService.ComputeSha256Hash(userLoginDto.Password);
        var user = await _serviceManager.UserService.GetUserAsync(userLoginDto.Email, passwordHash, false);
        
        var token = _serviceManager.TokenService.CreateToken(userLoginDto.Email, user.Status);
    
        return Ok(token);
    }
}